# tuples are just like list except the values cannot be changed after declaration

names = ('Chandler', 'Ross', 'Joey', 'Phoebe', 'Rachel', 'Monica')

#names[0] = 'test' # Returns type error : object does not support item assigenmnt

new_names = list(names)
new_names[0] = 'Chandler Bing'
print(new_names)

new_tuple = tuple(new_names)
print(new_tuple)