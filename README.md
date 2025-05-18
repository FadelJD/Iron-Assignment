# Iron-Assignment

For each input character:

If the character is a digit:
  - If it matches the previously processed digit, increment the press count for that digit.
  - If it's a new digit:
    * Commit the letter corresponding to the previous digit's presses (if any).
    * Set this new digit as the current `lastKey` and reset its `pressCount` to 1.

If the character is a space:
  - Commit the letter corresponding to the current `lastKey`'s presses (if any).
  - Clear the `lastKey` and `pressCount`.

If the character is an asterisk:
  - Commit the letter corresponding to the current `lastKey`'s presses (if any).
  - Clear the `lastKey` and `pressCount`.
  - If the result string has characters, remove the last one.

If the character is a hash:
  - Commit the letter corresponding to the current `lastKey`'s presses (if any).
  - Terminate the input processing.
