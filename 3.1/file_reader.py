from interfaces import IFileReader
from typing import Dict

class FileReader(IFileReader):
    def __init__(self):
        # Simulated in-memory storage of user preferences.
        # In a real-world scenario, this would likely involve reading from a file such as JSON or XML.
        self._prefs = {
            "alice": {"theme": "dark", "language": "en"},
            "bob": {"theme": "light", "language": "sv"},
            "carol": {"theme": "blue", "language": "fr"},
        }

    def read_preferences(self, username: str) -> Dict[str, str]:
        """
        Retrieve the stored preferences for a given user.

        Args:
            username (str): The username whose preferences should be retrieved.

        Returns:
            Dict[str, str]: A dictionary of preference settings.
                            Returns an empty dictionary if no preferences are found.
        """
        return self._prefs.get(username, {})