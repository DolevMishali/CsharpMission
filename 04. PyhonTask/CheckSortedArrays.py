import random

def find_sum_in_sorted_arrays(arr1, arr2, target_sum):
    i = 0
    j = len(arr2) - 1
    while i < len(arr1) and j >= 0:
        current_sum = arr1[i] + arr2[j]
        if current_sum == target_sum:
            return True
        elif current_sum < target_sum:
            i += 1
        else:
            j -= 1
    return False

def generate_sorted_array(n, start, end):
    return sorted(random.sample(range(start, end+1), n))

def main():
    arr1 = generate_sorted_array(15, 0, 30)
    arr2 = generate_sorted_array(12, 20, 60)
    target_sum=31
    result=find_sum_in_sorted_arrays(arr1, arr2, target_sum)
    print(result)
main()