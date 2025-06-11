package PrefixSum;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

public class CountVowelsInSubstring {

  // Problem Explanation: https://www.hellointerview.com/learn/code/prefix-sum/count-vowels

  //    Input: word = "prefixsum", queries = [[0, 2], [1, 4], [3, 5]]
  //    Output: [1, 2, 1]
  //    Explanation:
  //    word[0:3] -> "pre" contains 1 vowels
  //    word[1:5]-> "refi" contains 2 vowels
  //    word[3:6]-> "fix" contains 1 vowels

  // Tx = O(n + k) {n: word length, k: number of queries}
  // Sx = O(n + k)
  public List<Integer> vowelCountInRange(String word, List<List<Integer>> queries) {
    int[] prefixSum = new int[word.length()+1];
    HashSet<Character> vowels = new HashSet<>(Arrays.asList('a', 'e', 'i', 'o', 'u'));

    List<Integer> result = new ArrayList<>();

    for(int i=1; i<word.length()+1; i++){
      int isVowel = vowels.contains(word.charAt(i-1)) ? 1 : 0;
      prefixSum[i] = prefixSum[i-1] + isVowel;
    }

    for(int i=0; i<queries.size(); i++){
      List<Integer> query = queries.get(i);
      int startIndex = query.get(0);
      int endIndex = query.get(1);

      int count = prefixSum[endIndex+1] - prefixSum[startIndex+1];
      result.add(count);
    }

    return result;
  }
}
