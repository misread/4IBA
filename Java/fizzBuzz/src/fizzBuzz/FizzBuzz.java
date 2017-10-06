package fizzBuzz;

public class FizzBuzz {

	public static void main(String[] args) {
		for (int i = 1; i <= 100; i++) {
			boolean fizz = i % 3 == 0;
			boolean buzz = i % 5 == 0;
			if (fizz || buzz) {
				System.out.println((fizz ? "Fizz" : "") + (buzz ? "Buzz" : ""));
			}
			else {
				System.out.println(i);
			}
		}
	}

}
