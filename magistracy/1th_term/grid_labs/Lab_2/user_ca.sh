#!/bin/sh

echo "Please set Firstname"
read FIRSTNAME
echo "Please set Lastname"
read LASTNAME
echo "Please set EMAIL"
read EMAIL

CERTTYPE='people'
ENTITY='$FIRSTNAME $LASTNAME'
ORGUNIT='BITP'

########################################################################
##
## No user-serviceable parts below.
##
########################################################################
## $Id$
########################################################################
##
## The parameters are:
##  CERTTYPE - type of the certificate. Currently known are 'user', 'host'
## and 'service'
##  ORGUNIT - organisational unit name. Usually it is domain name of the
## institution.
##  ENTITY - name of the entity. For 'user' certificate it is the name of
## the person, for 'host' and 'service' certificates it is FQDN.
##  SERVTYPE - type of the service if we are working with the 'service'
## certificate. Unused in other certificate types.
##  FIRSTNAME - first name of the contact person.
##  LASTNAME - last name of the contact person.
##  EMAIL - electronic mailing address of the contact person
##  PHONE - phone of the contact person
##  NONGLOBUS - valid only for 'host' requests. If set, inhibits the
##  'host/' prefix in the CN of the request
##
########################################################################
##
## Those who are interested in the main code should skip up to the text
## label START_HERE
##
########################################################################

# VARIABLES ############################################################
CA="ca.bitp.kiev.ua"
OLDKEY=~/.globus/userkey.pem
OLDCERT=~/.globus/usercert.pem

# SANITY CHECK #########################################################

if test -z "$CERTTYPE"; then
	echo "CERTTYPE variable is not defined. Exiting." >&2
	exit 1
fi

if test -z "$ORGUNIT"; then
	echo "ORGUNIT variable is not defined. Exiting." >&2
	exit 1
fi

if test -z "$ENTITY"; then
	echo "ENTITY variable is not defined. Exiting." >&2
	exit 1
fi

if test -z "$FIRSTNAME"; then
	echo "FIRSTNAME variable is not defined. Exiting." >&2
	exit 1
fi

if test -z "$LASTNAME"; then
	echo "LASTNAME variable is not defined. Exiting." >&2
	exit 1
fi

if test -z "$EMAIL"; then
	echo "EMAIL variable is not defined. Exiting." >&2
	exit 1
fi


# SUBROUTINES ##########################################################

#
# Prints usage statement
#
usage () {
	cat <<"EOF"
Usage: newcert [-h | -help | --help] [directory]
 -h or -help or --help       print the usage statement

Parameter <directory> specifies the directory to store the new key file and
certification request. It will be created if it is possible. The default
directory is ~/.globus
EOF
}

#
# Waits for the [Enter] key to be pressed
#
any_key () {
	if test -t 0; then
		echo -n "Press [Enter]..."
		read dummy
	fi
}

#
# Checks is OpenSSL binary is present and good. Prints full path of the
# binary if it is good, otherwise dumps error message to the stderr and
# terminates the program
#
get_openssl () {
	local OPENSSL

	OPENSSL=`which openssl`
	if test -z "$OPENSSL"; then
		echo "Please, put the location of your OpenSSL binary into your PATH" >&2
		echo "and restart the key generation" >&2
		exit 1
	fi

	if ! test -x "$OPENSSL"; then
		echo "Found OpenSSL binary $OPENSSL, but it is not an executable" >&2
		echo "Please, modify your PATH variable for real OpenSSL to come first" >&2
		exit 1
	fi

	"$OPENSSL" version > /dev/null 2>&1
	if test "$?" -ne 0; then
		echo "OpenSSL binary $OPENSSL does not support the 'version' command" >&2
		echo "Looks like it is not an OpenSSL binary" >&2
		echo "Please, modify your PATH variable for real OpenSSL to come first" >&2
		exit 1
	fi

	echo "$OPENSSL"
}

#
# Prepares the directory for the new key. The directory name is determined
# by the following rules:
# - user certificate:
#   we are using the ~/.globus directory
# - host certificate:
#   we are using the ~/.globus/FQDN directory
# - service certificate:
#   we are using the ~/.globus/SERVICE-FQDN directory
# All directory values can be overriden with the first argument.
# The directory name will be exported to the global variable DIR.
#
# The file layout within that directory will be
# - user certificate:
#   userkey.pem, usercert.pem, userreq.pem, userreq.mail
# - host/service certificate:
#   hostkey.pem, hostcert.pem, hostreq.pem, hostreq.mail
# If some file already exists, then ALL file fill be postfixed with the
# current date up to the seconds. In this case the global variable NONSTDNAME
# will be set to "yes".
#
# The locations of the 4 aforementioned files will be saved in the global
# variables KEY, CERT, REQ and MAIL.
#
prepare_dir () {
	local DIR
	local DIRNAME
	local PREFIX
	local USERID
	local FOUND
	local UMASK

	DIR=""
	PREFIX=""
	case "$CERTTYPE" in
		people)
			DIR="$HOME/.globus"
			PREFIX="user"
			;;
		*)
			echo "Unknown certificate type $CERTTYPE. Exiting" >&2
			exit 1
			;;
	esac

	if test -n "$1"; then
		DIR="$1"
	fi

	DIRNAME="`basename "$DIR"`"

	# If directory will be created, then make it accessible only
	# to the user: we're checking for permissions below.
	UMASK=`umask`
	umask 0077

	if ! mkdir -p "$DIR"; then
		echo "Unable to create directory '$DIR'. Exiting" >&2
		exit 1
	fi
	umask "$UMASK"

	if test -h "$DIR"; then
		cat << EOF
------------------------------------------------------------------------
The directory '$DIR' is the symbolic link.
Additional safety checks will not be performed.
------------------------------------------------------------------------
EOF
		any_key
	else
		FOUND=`find "$DIR" -maxdepth 0 -name "$DIRNAME" -type d -perm +0022`
		if test "$FOUND" = "$DIR"; then
			cat << EOF

          WARNING! WARNING! WARNING!

Directory '$DIR' is group or world writeable.
This is insecure, since any malicious user can trick you to write
newly generated private key into his file. Please, restrict directory
rights to permit directory writes only to yourself or choose another
directory.

Typically the command to set the proper access rights to your directory
is 'chmod go= "$DIR"'.
Systems with extended ACL lists will require additional command
'setfacl -b "$DIR"'.

The key generation was canceled.
EOF
			exit 1
		fi
		USERID=`id -u`
		FOUND=`find "$DIR" -maxdepth 0 -name "$DIRNAME" -type d -user "$USERID"`
		if test "$FOUND" != "$DIR"; then
			echo "Directory '$DIR' is not owned by you."
			exit 1
		fi
	fi

	DATE=`date '+20%y%m%d-%H%M%S'`
	KEY="$DIR/${PREFIX}key"
	CERT="$DIR/${PREFIX}cert"
	REQ="$DIR/${PREFIX}req"
	MAIL="$DIR/${PREFIX}req"
	CONF="$DIR/openssl"

	NONSTDNAME="no"
	for i in "${KEY}.pem" "${CERT}.pem" "${REQ}.pem" "${MAIL}.mail" \
	  "${CONF}.conf"; do
		if test -f "$i"; then
			NONSTDNAME="yes"
			break
		fi
	done
	if test "$NONSTDNAME" = "yes"; then
		KEY="${KEY}.${DATE}.pem"
		CERT="${CERT}.${DATE}.pem"
		REQ="${REQ}.${DATE}.pem"
		MAIL="${MAIL}.${DATE}.mail"
		CONF="${CONF}.${DATE}.conf"
	else
		KEY="${KEY}.pem"
		CERT="${CERT}.pem"
		REQ="${REQ}.pem"
		MAIL="${MAIL}.mail"
		CONF="${CONF}.conf"
	fi

	# Be paranoid and check of we are not overwriting some file while
	# preparing the placeholders for our files.
	for i in "$KEY" "$CERT" "$REQ" "$MAIL" "$CONF"; do
		if test -f "$i"; then
			echo "File '$i' already exists and I will not overwrite it." >&2
			echo "I've took all steps to generate the unique name, but I've failed." >&2
			echo "User intervention needed." >&2
			exit 1
		fi
		if ! cp /dev/null "$i"; then
			echo "Unable to create file $i. Exiting." >&2
			exit 1
		fi
		chmod 0600 "$i"
	done

	# Exporting CONF and REQ for our cleanup handler
	export CONF
	export REQ

	cat >> "$CERT" << EOF
The issued certificate should be placed here. The corresponding key file is
  $KEY

You can always check if your certificate and your private key do correspond to
each other by issuing two commands
  $OPENSSL rsa -in $KEY -noout -modulus
  $OPENSSL x509 -in <your-certificate> -noout -modulus
and check that their outputs are the same.
EOF
}

#
# Get file names with old user cert and old private key
#
#get_names () {
#	local CERT
#	local KEY
#	local ENCRYPTED

#	echo "Please enter file name with your old certificate:"
#	read -p "[$OLDCERT]: " CERT
#	OLDCERT=${CERT:-$OLDCERT}

#	if [ ! -f "$OLDCERT" ]; then
#		echo "Cannot find your old certificate in $OLDCERT" >&2
#		echo "Did you specify the proper file? For " >&2
#		echo "personal certificates, it is usually in $HOME/.globus/usercert.pem" >&2
#		echo "Please locate your certificate and restart this script" >&2
#		exit 1
#	fi

#	if ! openssl x509 -noout -in "$OLDCERT" >/dev/null 2>&1 ; then
#		echo "It seems that $OLDCERT is not a certificate file."
#		echo "Please call this script with your old certificate file"
#		echo "in PEM format. Usually it's called usercert.pem."
#		exit 1
#	fi

#	echo "Please enter file name with your old private key:"
#	read -p "[$OLDKEY]: " KEY
#	OLDKEY=${KEY:-$OLDKEY}

#	if [ ! -f "$OLDKEY" ]; then
#		echo "Cannot find old key in $OLDKEY" >&2
#		echo "Please make sure your private key is still available" >&2
#		exit 1
#	fi

	# was old key encrypted
#	ENCRYPTED=`grep -c ENCRYPTED "$OLDKEY"`
#	if [ $ENCRYPTED -eq 0 ]; then
#		SSLFLAGS="-nodes "
#	fi

#}


#
# Prepare OpenSSL configuration file
#
make_openssl_conf () {
	if test "$CERTTYPE" = "people"; then
		cat >> "$CONF" << EOF
[ req ]
default_bits        = 2048
default_md	    = sha1
default_keyfile     = "$KEY"
distinguished_name  = req_dn
prompt              = no

[ req_dn ]

0.C = UA
0.DC = grid
1.O  = $ORGUNIT
0.OU = Education
0.CN = '$FIRSTNAME $LASTNAME'
EOF
#if test -n "$ORGUNIT2"; then
#cat >> "$CONF" << EOF  
#0.OU = $ORGUNIT2
#EOF
#fi

	else
		echo "Unknown certificate type $CERTTYPE. Exiting" >&2
		exit 1
	fi
}

#
# Tell user what will be going on
#
#notify_user () {
#	SUBJECT=`openssl x509 -noout -subject -in "$OLDCERT" | sed -e 's/^subject= *//'`

#	echo "------------------------------------------------------------------------"
#	echo "Using"
#	echo "  certificate: $OLDCERT"
#	echo "  private key: $OLDKEY"
#	echo "  subject:     $SUBJECT"
#	echo "  email:       $EMAIL"
#	echo "------------------------------------------------------------------------"

#	any_key
#}

#
# Creating new keypair
#
create_keypair () {
	local UMASK

	UMASK=`umask`
	umask=0277

	echo "">&2
	echo "Please enter a passphrase to protect your NEW private key" >&2
	echo "(note that you will have to type this same passphrase twice)" >&2
	openssl req $SSLFLAGS -new -config "$CONF" -out "$REQ" -keyout "$KEY"
	if [ $? -ne 0 -o ! \( -s "$KEY" -a -s "$REQ" \) ]; then
		echo "I could not properly generate a new key/request pair" >&2
		echo "The original files are unchanged, please try again" >&2
		exit 1
	fi

	umask "$UMASK"
	chmod 0400 "$KEY"
	chmod 0600 "$REQ"
}

#
# Obtains the public key modulus from the generated request file. Prints it
# to the standard output. In the case of errors, dumps the error message to
# the stderr and exits
#
get_modulus () {
	local MODULUS

	MODULUS=` "$OPENSSL" req -config "$CONF" -in "$REQ" -noout -modulus`

	if test "$?" -ne 0; then
		echo
		echo "OpenSSL was failed to extract modulus from your public key. Exiting" >&2
		exit 1
	fi
	MODULUS=`echo "$MODULUS" | sed -e 's/^Modulus=//'`
	if test -z "$MODULUS"; then
		echo
		echo "Failed to extract modulus from your public key"
		exit 1
	fi
	MODULUS=`echo "$MODULUS" | sed -e 's/^\(.\{10\}\)/\1 /'`
	MODULUS=`echo "$MODULUS" | sed -e 's/\(.\{10\}\)$/ \1/'`

	echo "$MODULUS"
}

#
# Creates the file to be mailed to the CA
#
create_mailfile () {
cat > "$MAIL" <<EOF
  Comment: upload this file using the renewal web interface at
  Comment: http://ca.bitp.kiev.ua
 
EOF
cat "$REQ" >> "$MAIL"

#echo "Please enter the passphrase for your OLD private key" >&2
#echo "in order to sign your e-mail request to the CA" >&2
#openssl smime -sign -in "$MAIL" -out "$MAIL.mime" \
#        -signer "$OLDCERT" -inkey "$OLDKEY" -text

#if [ `grep -c 'Content-Type: multipart/signed' "$MAIL.mime"` -ne 1 ] ; then
#  echo "" >&2
#  echo "!!! WARNING: an invalid S/MIME message may have been generated" >&2
#  echo "             please review the message in $newmail - " >&2
#  echo "             If something in this file looks like an error, please " >&2
#  echo "             mail the contents of this file to the CA in addition " >&2
#  echo "             to mailing the request as instructed" >&2
#  if [ ! -s "$MAIL.mime" ]; then
#    echo "" >&2
#    echo "The new request is empty, and does not contain a valid request." >&2
#    echo "Please review the error conditions above, or contact the CA" >&2
#    echo "for support. " >&2
#    echo "" >&2
#    echo "This rekeying script will now end." >&2
#    echo "" >&2
#    exit 1
#  fi
#  echo "" >&2
#  echo "             Note that the request must still be sent off to the CA" >&2
#  echo "             Sorry for the trouble." >&2
#  echo "" >&2
#fi

#mv "$MAIL.mime" "$MAIL"

#echo "" >&2
#echo "You have successfully generated your renewal (rekeying) request."
#echo "The renewal (rekeying) request is stored in the file"
#echo "$MAIL"
#echo "and you MUST now do the following:"
#echo ""
#echo "upload the file" 
#echo "$MAIL"
#echo "using the web interface at http://ca.bitp.kiev.ua/"
#echo ""
#echo "     Thank you for using the UGrid CA Service."
#echo ""
}

#
# Cleanup handler. Now just removes the OpenSSL configuration file and
# the original request file.
#
clean_up () {
	rm -f "$CONF" "$REQ" >/dev/null 2>&1
}

# START_HERE ###########################################################

# Command line
while test $# -ne 0; do
	case "$1" in
		-h|-help|--help)
			usage
			exit 0
			;;
		--)
			shift
			break
			;;
		-*)
			echo "Unknown option $1. Exiting" >&2
			exit 1
			;;
		*)
			break
			;;
	esac
	shift
done

trap 'any_key' EXIT

OPENSSL=`get_openssl`

# Variables DIR, KEY, CERT, REQ, MAIL and CONF will come into existence
prepare_dir "$1"

# Set variables OLDCERT, OLDKEY
#get_names

# OpenSSL configuration file will be set up
make_openssl_conf

# Tell user what will be made
#notify_user

create_keypair

create_mailfile

clean_up

exit 0