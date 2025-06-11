package Trie;

import DataStructures.TrieNode;

import java.util.List;

public class TrieMethods {
  TrieNode root;

  TrieMethods() {
    root = new TrieNode();
  }

  void createTrie(List<String> words) {
    TrieNode node = root;
    for(String word : words) {
      for(int i = 0; i < word.length(); i++) {
        char ch = word.charAt(i);
        int childrenIndex = ch - 'a';

        if(node.children[childrenIndex] == null) {
          node.children[childrenIndex] = new TrieNode();
        }
        node = node.children[childrenIndex];
      }

      node.isEndOfWord = true;
    }
  }

  void insert(String word) {
    TrieNode node = root;

    for(int i = 0; i < word.length(); i++) {
      char ch = word.charAt(i);
      int childrenIndex = ch - 'a';
      if(node.children[childrenIndex] == null){
        node.children[childrenIndex] = new TrieNode();
      }
      node = node.children[childrenIndex];
    }
    node.isEndOfWord = true;
  }

  boolean search(String word) {
    TrieNode node = root;

    for(int i=0; i<word.length(); i++) {
      char ch = word.charAt(i);
      int childrenIndex = ch - 'a';

      if(node.children[childrenIndex] == null) {
        return false;
      }
      node = node.children[childrenIndex];
    }

    return node.isEndOfWord;
  }

  void delete(String word) {
    if(delete(root, word, 0) {
      if(word.length() > 0 && root.children[word.charAt(0)] != null) {
        root.children[word.charAt(0)].isEndOfWord = false;
        root.children[word.charAt(0)] = null;
      }
    }
  }

  boolean delete(TrieNode node, String word, int index) {
    // base case: last index in the word
    if(index == word.length()-1){
      if(node.children[index] == null)
        return false;

      node = node.children[index];
      node.isEndOfWord = false;
      return isAllChildrenEmpty(node);
    }

    char ch = word.charAt(index);
    if(node.children[ch-'a']==null)
      return false;

    boolean deleteChild = delete(node, word, index+1);
    if(deleteChild) {
      node.children[ch-'a'] = null;
      return !node.isEndOfWord && isAllChildrenEmpty(node);
    }
    return false;
  }

  boolean isAllChildrenEmpty(TrieNode node){
    for(int i=0; i<node.children.length; i++){
      if(node.children[i] != null)
        return false;
    }
    return true;
  }
}
