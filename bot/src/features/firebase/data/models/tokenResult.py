from dataclasses import dataclass
from datetime import datetime


@dataclass
class TokenResult:
    id_token: str
    refresh_token: str
    expires_at: datetime
