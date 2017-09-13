class Animal:
    __name = ""  # private variable
    __height = 0
    __weight = 0

    # Constructor
    def __init__(self, name, height, weight):
        self.__name = name
        self.__height = height
        self.__weight = weight

    def get_name(self):
        return self.__name

    def get_height(self):
        return self.__height

    def get_weight(self):
        return self.__weight

    def toString(self):
        return "name is {}. Height is {}. Weight is {}".format(self.__name, self.__height, self.__weight)


cat = Animal("Pet", 12, 50)
print(cat.toString())


# Inheritance
class Dog(Animal):
    __owner = ""

    def __init__(self, name, height, weight, owner):
        self.__owner = owner
        super(Dog, self).__init__(name, height, weight)

    def toString(self):
        return "name is {}. Height is {}. Weight is {}. Owner is {}".format(self.__name, self.__height, self.__weight,
                                                                            self.__owner)


Ruby = Dog("Ruby", 50, 200, "John")
print(Ruby.toString())
