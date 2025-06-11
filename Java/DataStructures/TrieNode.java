package DataStructures;

public class TrieNode {
  public boolean isEndOfWord;
  public TrieNode[] children;

  public TrieNode() { }

  TrieNode(boolean isEndOfWord, TrieNode[] children) {
    this.isEndOfWord = isEndOfWord;
    this.children = children;
  }
}
