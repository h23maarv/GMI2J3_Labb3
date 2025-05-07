import unittest
from unittest.mock import MagicMock
from preferences_manager import PreferencesManager

class TestPreferencesManager(unittest.TestCase):
    def test_get_user_preferences_valid_user(self):
        mock_db = MagicMock()
        mock_file = MagicMock()

        mock_db.user_exists.return_value = True
        mock_file.read_preferences.return_value = {"theme": "dark", "language": "en"}

        manager = PreferencesManager(mock_db, mock_file)
        result = manager.get_user_preferences("alice")

        self.assertEqual(result["theme"], "dark")
        self.assertEqual(result["language"], "en")

    def test_get_user_preferences_invalid_user(self):
        mock_db = MagicMock()
        mock_file = MagicMock()
        mock_db.user_exists.return_value = False

        manager = PreferencesManager(mock_db, mock_file)

        with self.assertRaises(ValueError) as context:
            manager.get_user_preferences("dave")
        self.assertIn("User 'dave' not found", str(context.exception))

# Run the tests using these commands:
# python -m unittest test_preferences_manager.py
# coverage run -m unittest test_preferences_manager.py
# coverage report -m
# lizard .