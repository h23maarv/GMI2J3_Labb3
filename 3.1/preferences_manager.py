from interfaces import IDBClient, IFileReader
from typing import Dict

class PreferencesManager:
    def __init__(self, db_client: IDBClient, file_reader: IFileReader):
        self.db_client = db_client
        self.file_reader = file_reader

    def get_user_preferences(self, username: str) -> Dict[str, str]:
        if not self.db_client.user_exists(username):
            raise ValueError(f"User '{username}' not found")
        return self.file_reader.read_preferences(username)