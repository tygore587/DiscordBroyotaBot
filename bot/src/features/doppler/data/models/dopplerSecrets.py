from dataclasses import dataclass


@dataclass
class DopplerSecrets:
    firebase_api_key: str
    firebase_login_mail: str
    firebase_login_password: str
