import asyncio
from urllib.error import HTTPError

import httpx

from features.doppler.data.datasources.doppler_api_client_impl import DopplerApiClientImpl
from features.firebase.data.datasources.firebase_api_client_impl import FirebaseApiClientImpl, FirebaseLoginCredentials
from src.core.environmentHelper import EnvironmentHelper
from src.core.environmentVariables import EnvironmentVariables
from src.features.broyota_api.data.datasources.broyota_api_auth_flow import BroyotaApiAuthFlow
from src.features.broyota_api.data.datasources.broyota_api_client_impl import BroyotaApiClientImpl


async def main():
    try:
        EnvironmentHelper.load_environment()

        doppler_secret = EnvironmentVariables.get_doppler_service_token()

        doppler_client = httpx.AsyncClient()
        doppler_api_client = DopplerApiClientImpl(doppler_client)

        secrets = await doppler_api_client.get_secrets(base64_secret=doppler_secret)

        firebase_credentials = FirebaseLoginCredentials(email=secrets.firebase_login_mail,
                                                        password=secrets.firebase_login_password)
        firebase_client = httpx.AsyncClient()
        firebase_api_client = FirebaseApiClientImpl(firebase_client, secrets.firebase_api_key, firebase_credentials)

        broyota_api_auth_flow = BroyotaApiAuthFlow(firebase_api_client)
        broyota_client = httpx.AsyncClient(auth=broyota_api_auth_flow)
        broyota_api_client = BroyotaApiClientImpl(broyota_client)

        await broyota_api_client.get_example()
        await broyota_api_client.get_example()

    except HTTPError as err:
        print(err)
        exit(1)


if __name__ == '__main__':
    asyncio.run(main())
