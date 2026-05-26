// 20. Valid Parentheses
// https://leetcode.com/problems/valid-parentheses/
// Time: O(n) | Space: O(n)
public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> brackets = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        Stack<char> stack = new Stack<char>();

        foreach (char bracket in s)
        {
            // If it's not a closing bracket, it's an opening one. Push it to the stack.
            if (!brackets.ContainsKey(bracket))
            {
                stack.Push(bracket);
            }
            // It's a closing bracket, so it falls under here (else).
            else 
            {
                // If there's nothing in the opening brackets' stack, then there's a loose closing bracket. Return false.
                if (stack.Count <= 0)
                {
                    return false;
                }
                
                // Compare the most recent pushed opening bracket with the current closing bracket being evaluated. If it's a match, pop it from the stack. If it isn't, return false.
                if (brackets[bracket].Equals(stack.Peek()))
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }
        
        // If the stack isn't empty at the end of the foreach loop, then there's a loose opening bracket. Return false.
        if (stack.Count > 0) return false;

        // If none of the false conditions are met, return true for IsValid.
        return true;
    }
}
