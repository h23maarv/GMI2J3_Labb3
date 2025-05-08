# Using Python.org or Miniconda
# pip/conda install selenium webdriver-manager

import time
import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.common.exceptions import NoAlertPresentException
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service

def check_alert(num, text):
    """
    Check whether the alert text correctly identifies the number as prime or not.

    Args:
        num (int): The number that was submitted.
        text (str): The alert text displayed by the webpage.

    Raises:
        AssertionError: If the result in the alert does not match the expected outcome.
    """
    if num in {11, 13, 17, 19}:
        assert "true" in text.lower(), f"{num} should be prime!"
    else:
        assert "false" in text.lower(), f"{num} should not be prime!"

class PrimeGUITest(unittest.TestCase):
    def setUp(self):
        """
        Set up the Selenium Chrome WebDriver and navigate to the local HTML file.
        """
        self.driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
        self.driver.get("file:///CHANGEME/prime-assert1.html") # Change to your local path
        time.sleep(1)

    def tearDown(self):
        """
        Quit the WebDriver and close the browser after each test.
        """
        self.driver.quit()

    def test_prime_check(self):
        """
        Test whether the prime number checker correctly identifies primes from 10 to 19.

        For each number:
        - Clear and enter the number in the input field.
        - Click the submit button.
        - Wait for and read the alert box.
        - Assert that the alert message is correct based on known prime numbers.
        """
        driver = self.driver
        input_field = driver.find_element(By.ID, "primeinput")
        button = driver.find_element(By.ID, "inpbtn")

        for number in range(10, 20):
            input_field.clear()
            input_field.send_keys(str(number))
            button.click()

            time.sleep(0.5) # Wait for the alert to appear
            try:
                alert = driver.switch_to.alert
                alert_text = alert.text
                print(f"Alert text for {number}: {alert_text}")
                check_alert(number, alert_text)
                alert.accept()
            except NoAlertPresentException:
                print(f"No alert for {number}")

if __name__ == "__main__":
    unittest.main()

    # Run the tests using these commands in the terminal:
    #python primes-gui-test.py