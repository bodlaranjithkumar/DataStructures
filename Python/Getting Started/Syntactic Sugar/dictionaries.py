
key_values = {'a': 2,
              'b': 2,
              'c': 2,
              'd': 3,
              'e': 3,
              'f': 3,
              'g': 4,
              'h': 4,
              'i': 4,
              'j': 5}

print(key_values['a'])
print(key_values.get('a'))

# keys
print('Keys ', key_values.keys())

# keys contains
print('Keys contains ', key_values.keys().__contains__('a'))
print('Keys contains ', 'z' in key_values.keys())

# values
print('Values ', key_values.values())

# Values Contains
print('Values contains ', 2 in key_values.values())
print('Values contains ', 1 in key_values.values())

# len
print(len(key_values))

# delete
del key_values['a']
print(key_values)