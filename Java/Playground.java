import java.util.*;

public static void main(String[] args) {
    // array
    int[] arr = new int[3];
    int[] arr2 = {1,2,4,5,3};
	System.out.println(arr2[0]);
    System.out.println(arr2.length); // length
    Arrays.sort(arr2);
    System.out.println(arr2);

    // Matrix
    int[][] matrix = { {1,2,3}, {4,5,6}, {7,8,9} };
    System.out.println("rows:" + matrix.length);
    System.out.println("cols:" + matrix[0].length);

    // list
    List<Integer> list = new ArrayList<>();
    list.add(0);
    list.add(1);
    System.out.println(list.get(1));
    list.set(1,2);
    System.out.println(list.get(1));
    list.add(3);
    System.out.println(list.size()); // size
    list.remove(list.size()-1); // remove last element
    System.out.println(list.size());
    // Iterate
    for(int num : list) {
        System.out.println(num); 
    }

    list.stream().forEach(System.out::println); // Java 8 forEach
    list.forEach(System.out::println); // Java 8 forEach
    list.forEach(num -> System.out.println(num)); // Java 8 forEach

    // Hashset
    Set<Integer> set = new HashSet<>();
    set.add(1);
    set.add(2);
    System.out.println(set.add(2)); // returns false
    System.out.println(set.size()); // size
    System.out.println(set.contains(2)); // contains
    set.remove(2);
    for(int num : set) {
        System.out.println(num); // iterate
    }

    // HashMap
    Map<String, Integer> map = new HashMap<>();
    map.put("A", 1);
    map.put("B", 2);
    System.out.println(map.get("A"));
    System.out.println(map.containsKey("A")); // contains key
    System.out.println(map.containsValue(1)); // contains value
    System.out.println(map.size()); // size
    System.out.println(map.keySet().size()); // size
    System.out.println(map.values().size()); // values
    map.remove("B");
    System.out.println(map.size()); // size
    System.out.println(map.isEmpty()); // is empty
    map.getOrDefault("D", 0);
    map.putIfAbsent("C", 3); // Checks if the key is absent. If it is, it adds the key-value pair.
    System.out.println(map.size());
    for(Map.Entry<String, Integer> keyValue: map.entrySet()) {
        System.out.println(keyValue.getKey() + " " + keyValue.getValue());
    }
    // inserting values at the time of declaration
    static Map<Character, Character> paranthesesMap = Map.of(
            '(', ')',
            '{', '}',
            '[', ']'
    );

    // PriorityQueue
    List<Integer> l = Arrays.asList(5,1,3,4);
    PriorityQueue<Integer> minPQ = new PriorityQueue<Integer>(l);
    System.out.println(minPQ.offer(6));
    System.out.println(minPQ.peek());
    System.out.println(minPQ.poll());
    System.out.println(minPQ.size());

    PriorityQueue<Integer> maxPQ = new PriorityQueue<>((a,b) -> b-a); // decreasing order
}

