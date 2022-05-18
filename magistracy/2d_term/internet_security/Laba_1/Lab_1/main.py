import sys
import crypto
import random

from typing import Optional

from lab1.rsa import RSA, encrypt_string, decrypt_string

sys.modules['Crypto'] = crypto
from Crypto.Cipher import Salsa20


class Client(object):
    def __init__(self, name: str):
        self.name = name
        self._rsa = RSA()

    @property
    def public_key(self) -> int:
        return self._rsa.public_key

    @property
    def n(self) -> int:
        return self._rsa.n

    def decrypt_message(self, message: str, key: Optional[int] = None) -> str:
        return decrypt_string(encrypted_msg = message,
                              key           = self._rsa.private_key if key is None else key,
                              n             = self.n,
                              )

    def encrypt_message_for_client(self, message: str, client) -> str:
        return encrypt_string(message=message, key=client.public_key, n=client.n)

    def encrypt_file_for_client(self, file: str, client):
        secret = bytearray(''.join([str(random.randint(0, 9)) for i in range(32)]), encoding='utf-8')
        with open(file, 'rb') as f:
            data = f.read()
        cipher = Salsa20.new(key=secret)
        encrypted_data = cipher.nonce + cipher.encrypt(data)
        encrypted_file = f'encrypted_{file}'
        with open(encrypted_file, 'wb') as f:
            f.write(encrypted_data)
        return encrypted_file, self.encrypt_message_for_client(message=secret.decode(encoding='utf-8'), client=client)

    def decrypt_file(self, encrypted_file, encrypted_secret, key: Optional[int] = None):
        secret = bytearray(self.decrypt_message(message=encrypted_secret), encoding='utf-8')
        with open(encrypted_file, 'rb') as f:
            encrypted_data = f.read()
        msg_nonce, ciphertext = encrypted_data[:8], encrypted_data[8:]
        cipher = Salsa20.new(key=secret, nonce=msg_nonce)
        data = cipher.decrypt(ciphertext)
        with open(encrypted_file.replace('encrypted_', 'decrypted_'), 'wb') as f:
            f.write(data)

    def __str__(self) -> str:
        return self.name


def main():
    client1 = Client('Denys')
    client2 = Client('Dmytro')
    man_in_middle = Client('ManInMiddle')

    message = 'Hello Denys, the weather is fine!'
    print(f'{client2} wants to send message to {client1}: "{message}"')
    encrypted_message = client2.encrypt_message_for_client(message=message, client=client1)
    print(f'Encrypted message: {encrypted_message}')

    print(f'{man_in_middle} is trying to decrypt the message...')
    assert man_in_middle.decrypt_message(message=encrypted_message) != message, 'Success'
    assert man_in_middle.decrypt_message(message=message, key=client1.public_key) != message, 'Success'
    assert man_in_middle.decrypt_message(message=message, key=client2.public_key) != message, 'Success'
    print(f'No success')

    print(f'{client1} is trying to decrypt the message...')
    decrypted_message = client1.decrypt_message(encrypted_message)
    assert decrypted_message == message, 'Failed'
    print(f'Success, message: "{decrypted_message}"')

    print('-' * 50)
    print(f'{client2} wants to send file to {client1}')
    encrypted_file, encrypted_secret = client2.encrypt_file_for_client(file='data.txt', client=client1)

    print(f'{client1} is decrypting the file...')
    client1.decrypt_file(encrypted_file=encrypted_file, encrypted_secret=encrypted_secret)

    print(f'{client1} is trying to decrypt the file...')


if __name__ == '__main__':
    main()
