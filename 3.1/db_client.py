from interfaces import IDBClient

class DBClient(IDBClient):
    def __init__(self):
        self._users = {"alice", "bob", "carol"}

    def user_exists(self, username: str) -> bool:
        return username in self._users