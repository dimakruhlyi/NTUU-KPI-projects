import random
from typing import Tuple, List


def get_prime_number(start: int = 100, end: int = 1000) -> int:
    while True:
        number = int(start + random.random() * (end - start))
        for i in range(2, number):
            if (number % i) == 0:
                break
        else:
            return number


class RSA(object):
    def __init__(self):
        self._p = get_prime_number(start=100, end=1000)
        while True:
            self._q = get_prime_number(start=100, end=1000)
            if self._q != self._p:
                break
        self._n = self._p * self._q
        self._phi = (self._p - 1) * (self._q - 1)

        self._public_key = get_prime_number(start=1, end=self._phi - 1)
        self._private_key = _modinv(self._public_key, self._phi)

    def __str__(self) -> str:
        return f'Public key is a pair of numbers (e={self._public_key}, n={self._n})\n' \
               f'Private key is a pair of numbers (d={self._private_key}, n={self._n}\n'

    @property
    def public_key(self) -> int:
        return self._public_key

    @property
    def private_key(self) -> int:
        return self._private_key

    @property
    def n(self) -> int:
        return self._n


def _extended_gcd(a: int, b: int) -> Tuple[int, int, int]:
    if not a:
        return b, 0, 1
    g, y, x = _extended_gcd(b % a, a)
    return g, x - (b // a) * y, y


def _modinv(a: int, m: int) -> int:
    g, x, y = _extended_gcd(a=a, b=m)
    if g != 1:
        raise Exception('modular inverse does not exist')
    return x % m


def encrypt_block(message: int, key: int, n: int) -> int:
    c = _modinv(a = message ** key, m = n)
    assert c is not None, f'No modular multiplicative inverse for block {message}'
    return c


def decrypt_block(message: int, key: int, n: int) -> int:
    m = _modinv(a = message ** key, m = n)
    assert m is not None, f'No modular multiplicative inverse for block {message}'
    return m


def encrypt_string(message: str, key: int, n: int) -> str:
    return ''.join(
        str(chr(
            encrypt_block(message=ord(x), key=key, n=n)
        ))
        for x in message
    )


def decrypt_string(encrypted_msg: str, key: int, n: int) -> str:
    return ''.join(
        str(chr(
            decrypt_block(message=ord(x), key=key, n=n)
        ))
        for x in encrypted_msg
    )


if __name__ == '__main__':
    # rsa = RSA()
    # print(rsa)
    #
    # message = 'Hello Denys, the weather is fine!'
    # print(f'Plain message: {message}')
    # enc = encrypt_string(message=message, key=rsa.public_key, n=rsa.n)
    # print("Encrypted message: " + enc + "\n")
    # dec = decrypt_string(encrypted_msg=enc, key=rsa.private_key, n=rsa.n)
    # print("Decrypted message: " + dec + "\n")



    from Crypto.Cipher import AES
    key = b'Sixteen byte key'
    cipher = AES.new(key, AES.MODE_EAX)
    plaintext = cipher.decrypt('HelloWorld')

