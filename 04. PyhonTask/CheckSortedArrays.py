import random # necessary for the test.

def find_sum_in_sorted_arrays(arr1, arr2, target_sum):
    
    # Initialize two pointers: i for arr1 pointing to the start, j for arr2 pointing to the end
    i = 0
    j = len(arr2) - 1
    
    # Loop through the arrays while i is less than the length of arr1 and j is greater than or equal to 0
    while i < len(arr1) and j >= 0:
        current_sum = arr1[i] + arr2[j]
        
        # If current_sum is equal to target_sum, we found the sum we're looking for, return True
        if current_sum == target_sum:
            return True
        
         # If current_sum is less than target_sum, we need a larger sum, increment i to increase the sum
        elif current_sum < target_sum:
            i += 1
            
        # If current_sum is greater than target_sum, we need a smaller sum, decrement j to decrease the sum
        else:
            j -= 1
    return False

# -------- Supporting method for the test. -------- 
def generate_sorted_array(n, start, end):
    return sorted(random.sample(range(start, end+1), n))

# -------- The main method is for testing the method. -------- 
def main():
    arr1 = generate_sorted_array(15, 0, 30)
    arr2 = generate_sorted_array(12, 20, 60)
    target_sum=31
    result=find_sum_in_sorted_arrays(arr1, arr2, target_sum)
    print(result)
main()