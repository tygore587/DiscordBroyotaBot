from dataclasses import dataclass


@dataclass
class FirebaseLoginCredentials:
    email: str
    password: str
