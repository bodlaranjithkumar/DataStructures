def even_entries_first(A):
    even_value_index, odd_value_index = 0, len(A) - 1
    while even_value_index < odd_value_index:
        if A[even_value_index] % 2 == 0:
            even_value_index += 1
        else:
            A[even_value_index], A[odd_value_index] = A[odd_value_index], A[even_value_index]
            odd_value_index -= 1

    return A


input_array = [4, 6, 5, 9, 3, 2, 1, 11]
print(even_entries_first(input_array))

even_array = [2, 4, 6, 8]
print(even_entries_first(even_array))

odd_array = [5, 9, 7, 1, 3]
print(even_entries_first(odd_array))
