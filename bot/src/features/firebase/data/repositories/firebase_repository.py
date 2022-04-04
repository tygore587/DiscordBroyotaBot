from dataclasses import dataclass
from datetime import datetime

from features.firebase.data.datasources.firebase_api_client import FirebaseApiClient, FirebaseLoginCredentials


@dataclass
class FirebaseTokenInfo:
    id_token: str
    refresh_token: str
    expires_at: datetime
    display_name: str


class FirebaseRepository:
    # TODO: Don't hold token, get token from firebase_api_client or insert firebase api client into all repositories which talkes to my backend
    token_info: FirebaseTokenInfo

    def __init__(self, api_client: FirebaseApiClient, creds: FirebaseLoginCredentials):
        self.api_client = api_client
        self.creds = creds
