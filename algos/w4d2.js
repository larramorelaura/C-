/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
  constructor() {
    this.items = [];
  }

  /**
   * Adds a new given item to the back of this queue.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @param {any} item The new item to add to the back.
   * @returns {number} The new size of this queue.
   */
  enqueue(item) {
    this.items.push(item);
    return this.size();
  }

  /**
   * Removes and returns the first item of this queue.
   * - Time: O(n) linear, due to having to shift all the remaining items to
   *    the left after removing first elem.
   * - Space: O(1) constant.
   * @returns {any} The first item or undefined if empty.
   */
  dequeue() {
    return this.items.shift();
  }

  /**
   * Retrieves the first item without removing it.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {any} The first item or undefined if empty.
   */
  front() {
    return this.items[0];
  }

  /**
   * Returns whether or not this queue is empty.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {boolean}
   */
  isEmpty() {
    return this.size() === 0;
  }

  /**
   * Retrieves the size of this queue.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {number} The length.
   */
  size() {
    return this.items.length;
  }
}

// const emptyList = new Queue();

// console.log(emptyList.size())
// console.log(emptyList.isEmpty())

// const unorderedList = new Queue()

// console.log(unorderedList)

// unorderedList.enqueue(8)
// unorderedList.enqueue(4)
// unorderedList.enqueue(10)

// console.log(unorderedList);
// console.log(unorderedList.enqueue(3))
// console.log(unorderedList.dequeue())
// console.log(unorderedList)
// console.log(unorderedList.front())

/* Rebuild the above class using a linked list instead of an array. */

class QueueNode {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class LinkedListQueue {
  constructor() {
    this.head = null;
    this.size = 0;
  }

  enqueue(item) {
    const newNode = new QueueNode(item);
    if (this.head === null) {
      this.head = newNode;
    } else {
      newNode.next = this.head;
      this.head = newNode;
    }
    this.size += 1;
    return this.size;
  }

  front() {
    return this.head.data;
  }

  toArr() {
    const arr = [];
    let runner = this.head;

    while (runner) {
      arr.push(runner.data);
      runner = runner.next;
    }
    return arr;
  }
}

const emptyList = new LinkedListQueue();
console.log(emptyList);

const unorderedList = new LinkedListQueue();
unorderedList.enqueue(4);
unorderedList.enqueue(6);
console.log(unorderedList.enqueue(2));
console.log(unorderedList.toArr());
console.log(unorderedList.front());

console.log();
