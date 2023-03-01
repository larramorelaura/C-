const { Stack } = require("./w4d1");

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
        return this.items.length === 0;
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

    /**
     * Compares this queue to another given queue to see if they are equal.
     * Avoid indexing the queue items directly via bracket notation, use the
     * queue methods instead for practice.
     * Use no extra array or objects.
     * The queues should be returned to their original order when done.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Queue} q2 The queue to be compared against this queue.
     * @returns {boolean} Whether all the items of the two queues are equal and
     *    in the same order.
     */
    compareQueues(q2) { 
        if(this.size() !== q2.size())
        {
            return false;
        }
        // else{
        //     return true;
        // }
        let count=1;
        // console.log("before while: " +this.items)
        let first = this.dequeue();
        this.enqueue(first);

        let secondToCompare= q2.dequeue();
        q2.enqueue(secondToCompare);
        let output=true;
        // console.log("after setting: " +this.items)
        //requeue the first and compare it to the current first
        while(count!==this.size())
        {
            first=this.dequeue();
            this.enqueue(first);
            secondToCompare=q2.dequeue();
            q2.enqueue(secondToCompare);
            count++;
            if(first!==secondToCompare)
            {
                output=false;
            }
            // console.log(this.items)
        }
        return output;
    }

    /**
     * Determines if the queue is a palindrome (same items forward and backwards).
     * Avoid indexing queue items directly via bracket notation, instead use the
     * queue methods for practice.
     * Use only 1 stack as additional storage, no other arrays or objects.
     * The queue should be returned to its original order when done.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isPalindrome() {
        let stack= new Stack();
        let count=1;
        let toStack = this.dequeue();
        this.enqueue(toStack)
        stack.push(toStack);
        while(count!==this.size())
        {
        toStack=this.dequeue()
        this.enqueue(toStack);
        stack.push(toStack);
        // console.log(stack)
        count++;
        }
        count=1;
        let output=true
        while (count<this.size())
        {
            let queueValue = this.dequeue();
            this.enqueue(queueValue)
            let stackValue= stack.pop();
            if(queueValue!==stackValue)
            {
                output=false;
            }
            count++;
        }
        return output;
    }
}

const unorderedList = new Queue()

console.log(unorderedList)

unorderedList.enqueue(8)
unorderedList.enqueue(4)
unorderedList.enqueue(10)

const orderedList = new Queue()
orderedList.enqueue(4)
orderedList.enqueue(8)
orderedList.enqueue(10)

const shortList = new Queue()
shortList.enqueue(2)
shortList.enqueue(12)
shortList.enqueue(16)

const longList= new Queue()
longList.enqueue(2)
longList.enqueue(12)
longList.enqueue(16)
longList.enqueue(24)
longList.enqueue(32)

const secondorderedList= new Queue()
secondorderedList.enqueue(4)
secondorderedList.enqueue(8)
secondorderedList.enqueue(10)

const car = new Queue()
car.enqueue("r")
car.enqueue("a")
car.enqueue("c")
car.enqueue("e")
car.enqueue("c")
car.enqueue("a")
car.enqueue("r")

// console.log(secondorderedList.compareQueues(orderedList))
// console.log(secondorderedList)
// console.log(longList.compareQueues(orderedList))
// console.log(unorderedList.compareQueues(orderedList))
console.log(car.isPalindrome())
console.log(longList.isPalindrome())