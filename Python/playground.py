# use the runner to run this program. Shortcut: ctrl + alt + n. 
# to stop use ctrl + alt + m

import math
print("hello word")
print("*" * 10)  # prints * 10 times

# Variables
# Type of variables are determined at runtime unlike compile time in java
student_count = 1000    # type int
rating = 4.99  # type float
is_published = True  # type boolean
course_name = "Python Programming"  # type str
multi_lines = """
    This is a multi 
    line string"""
x, y = 1, 2  # multiple assignment
n = m = 1
# constant. hence capital casing. Value shouldn't be changed although python doesn't enforce this.
MY_PI = 3.14

print(type(student_count))  # prints type of variable
print(id(student_count))  # prints memory address of variable

######## int #######
# strings, boolean, float, integers are immutable in python. At sometime python garbage collector will automatically release the memory for foregone variables
x = x+1
print(id(x))  # prints new memory address of variable

# however lists are mutable in python.
my_list = [1, 2, 3]
print(id(my_list))

my_list.append(4)
print(id(my_list))  # prints same memory address

######## string #######
course = "Python Programming"
print(len(course))  # prints length of string - 18
print(course[0])  # prints first character - 'P'
print(course[-1])  # prints last character - 'g'
print(course[-2])  # prints second last character - 'n'
print(course[0:3])  # prints the first 3 characters - 'Pyt'
print(course[0:])  # prints the entire string - 'Python Programming'
print(course[:3])  # prints the first 3 characters - 'Pyt'
print(course[:])  # prints the entire string - 'Python Programming'

# prints different addresses for substring as strings are immutable
print(id(course))
print(id(course[:1]))

# formatted strings
first_name = "Donald"
last_name = "Buffet"
full_name = f"{first_name} {last_name}. Length: {len(first_name) + len(last_name)}"
print(full_name)

# string methods
course = "   Python Programming "
print(course.upper())
print(course.lower())
print(course.title())  # capitalizes first letter of each word
print(course.strip())  # removes leading and trailing spaces
print(course.lstrip())  # removes leading spaces
print(course.rstrip())  # removes trailing spaces
# returns index of substring. Does a case sensitive search. -1 if not found
print(course.find("programming"))
print(course.replace("r", "*"))  # replaces all occurrences of substring
# returns true if substring is found. Does search case sensitive.
print("pro" in course)


######## Integers #########
x = 10
x = 0b10  # binary. Number 2

print(x)
print(bin(x))  # prints binary representation of number. 0b10.

x = 0x12c  # hex. Number 300
print(x)  # prints 300.


print(math.floor(MY_PI))  # prints 3
print(abs(-2.9))  # prints 2.9


##### Type Conversion ####
# x = input("x: ")
print(type(x))  # prints string
print(int(x))  # prints int
print(float(x))  # prints float
print(bool(x))  # returns false for empty string

# falsy values in python: 0, null, empty string, empty list, empty tuple, empty dictionary, empty set, False

###### Conditional Statements ######
age = 5
if age >= 18:
    print("Adult")
elif age >= 13:
    print("Teenager")
else:
    print("Child")

#### Logical Operations ###
name = ""

if not name:    # name is empty string. Converting this to bool will result in false value. Hence not name is true
    print("Name is empty")

if 18 <= age < 65:      # Equivalent to age >= 18 and age < 65:
    print("Eligible")
else:
    print("Not eligible")

# Above can be rewritte in plain english as:
message = "Eligible" if 18 <= age < 65 else "Not eligible"

##### Loops #####

for c in "Python":
    print(c)

for i in range(10):  # range 0:10
    print(i)

for i in range(5, 10):  # start and end range
    print(i)

# start, end and step. Increment by 2 on each iteration.
for i in range(0, 10, 2):
    print(i)


# For Else
names = ["FAM", "PRIME"]

for name in names:
    if name.startswith("A"):
        print("Found")
        break
else:
    print("Not found")

# While loop

# guess = 0
# answer = 5

# while guess != answer:
#     guess = int(input("Guess: "))
#     if guess == answer:
#         print("You guessed it right")
#         break
# else:
#     print("You failed")

##### Functions #####


def increment(number, by):
    return number + by

# def increment(number, by=1): # default value for by is 1
#     return number + by

# def increment(number: int, by: int = 1) -> int:  # type hinting
#     return number + by

# def increment(number: int, by: int = 1) -> tuple:  # type hinting
#     return (number, number + by)

print(increment(2, 3))
print(increment(2, by=3))  # named arguments


#### Arguments #####
def multiply(*numbers):  # variable number of arguments. The argument allows us to pass multiple arguments to the function
    print(type(numbers)) # tuple
    total = 1
    for number in numbers:
        total *= number
    return total

print(multiply(2,3,4,5))

# variation to above function by passing variable arguments using **. This will create a dictionary.
def save_user(**user):
    print(user)
    print(user["id"])
    #print(user["last_name"]) # throws key error if key is not found

save_user(id=1, name="Matt", age=22)

def fizz_buzz(number):
    if number % 3 == 0 and number % 5 == 0:
        return "FizzBuzz"
    if number % 3 == 0:
        return "Fizz"
    if number % 5 == 0:
        return "Buzz"
    return number

print(fizz_buzz(15))
print(fizz_buzz(3))
print(fizz_buzz(5))
print(fizz_buzz(7))


##### Data Structures #######


##### Lists #####
letters = ["a", "b", "c"]
matrix = [[0, 1], [2, 3]] # 2D list
zeros = [0] * 5 # creates a list of 5 zeros
combined = zeros + letters # concatenation of lists with different types
numbers = list(range(20)) # creates a list of numbers from 0 to 19 by iterating.
characters = list("Hello World") # creates a list of characters

numbers = list(range(20))
print(numbers[::2]) # prints the numbers at even indexes
print(numbers[::-1]) # prints numbers in reverse order

# list unpacking
my_list = [1, 2, 3, 4, 5]
first, second, *others = my_list
print(first, second, others)

first, *others, last = my_list
print(first, others, last)

# iterate list
for item in my_list: # iterate without index
    print(item)

for index, item in enumerate(my_list): # use built in enumerate function to iterate list with index
    print(f"item at index: {index} is {item}")

# find index of item in list
print(my_list.index(3)) # prints index of item 3 if found. Otherwise, returns value error.

# check if item is in list
if 6 in my_list:
    print(my_list.index(6))
else:
    print("Not found")

# count number of occurrences of item in list
print(my_list.count(3))

# add/remove/update items in the list
my_list.append(6)
print(my_list)

my_list.insert(0, 0)
print(my_list)

my_list.pop() # removes last item
print(my_list)

my_list.pop(0) # removes first item
print(my_list)

my_list.remove(3) # removes first occurrence of item 3
print(my_list)

del my_list[0:2] # removes items at index 0 and 1
print(my_list)

# my_list.clear() # removes all items in the list
# print(my_list)

# sort
my_list.sort() # sorts the list in ascending order
my_list.sort(reverse=True) # sorts the list in descending order
print(sorted(my_list, reverse=True)) # returns a new list with sorted values

# sort list of tuples
items = [
    ("Product1", 10),
    ("Product2", 9),
    ("Product3", 12)
]

items.sort(key=lambda item: item[1]) # sorts based on price
print(items)

# fetch price of each item. Common way is to iterate over the items and get the price. However, using map function is more elegant.
prices = list(map(lambda item: item[1], items)) # map returns an object of map type. Hence, we need to convert it to list.
print(prices)
# a more cleaner and performant way to do the same is to use list comprehension
prices = [item[1] for item in items]
print(prices)

filtered = list(filter(lambda item: item[1] >= 10, items)) # filter items with price greater than 10
print(filtered)
filtered = [item for item in items if item[1] >= 10] # list comprehension
print(filtered)

my_list1 = [1,2,3]
my_list2 = ['a','b','c']
# to combine the two lists as tuples, we can use zip function
print(list(zip(my_list1, my_list2))) # returns [(1, 'a'), (2, 'b'), (3, 'c')]


