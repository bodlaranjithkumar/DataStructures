
names = ['Chandler','Ross','Joey','Phoebe','Rachel','Monica']
print('First Name = ', names[0])
print('First 3 names', names[0:3])

more_names = ['Gunther','Mark']

combined_names = [names, more_names]
print('Combined names ', combined_names)
print('First First :', combined_names[0][0])
print('Second First :', combined_names[1][0])

# append
more_names.append("Russ")
print('Combined names ', combined_names)


#combined_names.append("Test")
print('Appended Combined names ', combined_names)

# sort
combined_names.sort()
print('Sorted Combined names ', combined_names)

# delete item at index
del more_names[2]
print('deleted more names', more_names)

# remove item with a value
more_names.remove("Gunther")
print('Removed more names', more_names)

# length
print('combined names length', len(combined_names))
print('names length', len(names))

# max, min
print('names max', max(names))
print('names min', min(names))

# use for lop to print all names
for cnames in range(0,len(combined_names)):
    for name in range(0, len(combined_names[cnames])):
        print('name', combined_names[cnames][name])

