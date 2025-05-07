from interfaces import IFileReader
from typing import Dict

class FileReader(IFileReader):
    def __init__(self):
        self._prefs = {
            "alice": {"theme": "dark", "language": "en"},
            "bob": {"theme": "light", "language": "sv"},
            "carol": {"theme": "blue", "language": "fr"},
        }

    def read_preferences(self, username: str) -> Dict[str, str]:
        return self._prefs.get(username, {})