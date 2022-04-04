from urllib.error import HTTPError
from core.environment import EnvironmentHelper, EnvironmentVariables
from features.doppler.data.datasources.doppler_api_client import DopplerApiClient
from features.firebase.data.datasources.firebase_api_client import FirebaseApiClient, FirebaseLoginCredentials


def main():
    try:
        EnvironmentHelper.load_environment()

        doppler_secret = EnvironmentVariables.get_doppler_service_token()

        doppler_client = DopplerApiClient()

        secrets = doppler_client.get_secrets(base64_secret=doppler_secret)

        firebase_api_client = FirebaseApiClient(secrets.firebase_api_key)

        firebase_credentials = FirebaseLoginCredentials(email=secrets.firebase_login_mail,
                                                        password=secrets.firebase_login_password)

        creds = firebase_api_client.login_user(
            credentials=firebase_credentials)
        print(creds.id_token)

    except HTTPError as err:
        print(err)
        exit(1)


if __name__ == '__main__':
    main()
