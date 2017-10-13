import sys

# Append strings
str1 = "\"Hello"
str2 = "World"
print("%s %s %s" % ('This is a sample of ', str1, str2))

long_string = "this is a long string"
print('First 4 chars: ', long_string[0:4]) # First 4 characters
print('Last 6 chars: ', long_string[-6:]) # last 6 characters
print('All chars except last 6: ',long_string[:-6]) # All characters except last 6

print('Capitalize first letter for the string: ', long_string.capitalize())
print('Casesensitive Index find: ', long_string.find('long'))
print('Are all characters letters? ',long_string.isalpha())
print('All characters are numbers? ', '123'.isalnum())
print('Remove white space at the end: ', long_string.strip())
print('Split into list: ', long_string.split(" "))

s = 'python,is,powerful,programming,language'.split(',')
print(s)

name = ','.join(('ranjith','kumar', 'bodla'))   # join using the list of values using the , delimiter.
print(name)


nameformat = 'Name name, Lname lname'.format(name='Ranjith', lname='Bodla')
print(nameformat)

# strings in python are immutable i.e., appending a character to existing string creates a new string
# so, mutable version of string is list
s = s[1:]
s += '123'

# read input from command line
print('What is your name?')
name = sys.stdin.readline()
print(name)