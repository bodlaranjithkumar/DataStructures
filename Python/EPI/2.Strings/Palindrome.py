def is_palindrome(s):
    return all(s[i] == s[~i] for i in range(len(s) // 2))

    # references:
    # all :     https://www.programiz.com/python-programming/methods/built-in/all
    #           https://docs.python.org/3/library/functions.html?highlight=all#all

    # range:     https://www.programiz.com/python-programming/methods/built-in/range

    # // is division


print(is_palindrome('civic'))
print(is_palindrome('name e man'))
