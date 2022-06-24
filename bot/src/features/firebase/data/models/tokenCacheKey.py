from dataclasses import dataclass


@dataclass(frozen=True, eq=True)
class TokenCacheKey:
    email: str
    password: str
