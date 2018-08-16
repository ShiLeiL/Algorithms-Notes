a. System.out.println('b');　　　　　　　　b<br>
b. System.out.println('b' + 'c');　　　　　　197,被隐式转换为int类型，即取b和c对应的ASCII码相加<br>
c. System.out.println((char) ('a' + 4));　　　e，字符串a被隐式转换成int类型与4相加后，再强制转换成char类型<br>
