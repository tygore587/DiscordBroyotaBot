from dataclasses import dataclass
from requests import HTTPError
import requests

from src.firebase_api_client import FirebaseApiClient, FirebaseLoginCredentials


@dataclass
class DopplerSecrets:
    firebase_api_key: str
    firebase_login_mail: str
    firebase_login_password: str


def get_secrets(base64_secret: str) -> DopplerSecrets:
    headers = {
        "Authorization": f'Basic {base64_secret}'}

    response = requests.get(f'https://api.doppler.com/v3/configs/config/secrets/download?format=json', headers=headers)

    response.raise_for_status()

    content = response.json()

    fb_api_key = str(content['FIREBASE_API_KEY'])
    fb_login_mail = str(content['FIREBASE_LOGIN_MAIL'])
    fb_login_password = str(content['FIREBASE_LOGIN_PASSWORD'])

    return DopplerSecrets(firebase_api_key=fb_api_key, firebase_login_mail=fb_login_mail,
                          firebase_login_password=fb_login_password)


def main():
    try:
        doppler_secret = ""
        secrets = get_secrets(base64_secret=doppler_secret)

        firebase_api_client = FirebaseApiClient(secrets.firebase_api_key)

        firebase_credentials = FirebaseLoginCredentials(email=secrets.firebase_login_mail,
                                                        password=secrets.firebase_login_password)

        creds = firebase_api_client.login_user(credentials=firebase_credentials)
        print(creds.id_token)
    except HTTPError as err:
        print(err)
        exit(1)


if __name__ == '__main__':
    main()
