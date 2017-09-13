import os

test_file = open("test.txt","wb")   # open the file in wb (write mode)

print(test_file.mode)

print(test_file.name)

test_file.write(bytes("sample text write into the file\n", 'UTF-8'))

test_file.close()


test_file = open("test.txt","r+") # read and write
text_in_file = test_file.read()
print(text_in_file)

os.remove("test.txt")