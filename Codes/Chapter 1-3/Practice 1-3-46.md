因为三元组(a,b,c)的弹出顺序要求是c最先，a第二，b第三。<br>
且a < b < c，即压入栈顺序为a，b，c。<br>
则在c压入之前，a，b还留在栈内。<br>
根据栈的先进后出的特性，还留在栈内的b必定在a之上，则无法达到a比b先弹出的效果，与原题要求不符，故栈无法成立。<br>