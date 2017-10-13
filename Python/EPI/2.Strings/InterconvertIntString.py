def integer_to_string(number):
    is_negative = False
    if number < 0:
        number, is_negative = -number, True

    digits = []
    while True:
        remainder = number % 10
        quotient = number // 10
        digits.append(chr(ord('0') + remainder))
        number = quotient
        if number == 0:
            break

    return ('-' if is_negative else '') + "".join(reversed(digits))


# print(integer_to_string(123))


def string_to_integer(s):
    number = 0
    is_negative = False
    start_index = 1

    if s[0] == '-':
        is_negative = True
    elif s[0].isdigit():
        start_index = 0

    length = len(s)
    for i in range(start_index, length, 1):
        if not s[i].isdigit():
            break
        # number += (ord(s[i]) - ord('0')) * 10 ** (length - i - 1)
        number = number * 10 + (ord(s[i]) - ord('0'))

    return (-1 if is_negative else 1) * number


print(string_to_integer("123"))
print(string_to_integer("-123"))
print(string_to_integer("-123.00"))


# references
# ord   Returns the unicode code value for the given unicode character
#       https://www.programiz.com/python-programming/methods/built-in/ord

# chr   Returns a character from an integer(represents unicode point of the character).
#       https://www.programiz.com/python-programming/methods/built-in/chr
