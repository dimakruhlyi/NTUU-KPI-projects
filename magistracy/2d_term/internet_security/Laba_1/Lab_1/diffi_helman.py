import random


class DH(object):
    def __init__(self):
        self._private_key = random.getrandbits(8)

        self._shared_base  = None
        self._shared_prime = None
        self._key          = None

    def set_shared(self, shared_base, shared_prime):
        self._shared_base = shared_base
        self._shared_prime = shared_prime

    def generate_partial_key(self):
        return (self._shared_base ** self._private_key) % self._shared_prime

    def generate_key(self, partial_key):
        self._key = (partial_key ** self._private_key) % self._shared_prime


def main():
    shared_prime = 23
    shared_base  = 5

    alice = DH()
    bob   = DH()
    alice.set_shared(shared_base=shared_base, shared_prime=shared_prime)
    bob.set_shared(shared_base=shared_base, shared_prime=shared_prime)

    alice.generate_key(partial_key=bob.generate_partial_key())
    bob.generate_key(partial_key=alice.generate_partial_key())
    print(alice._private_key)
    print(bob._private_key)

    print(alice._key)
    print(bob._key)


if __name__ == '__main__':
    main()
