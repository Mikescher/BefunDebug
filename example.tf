/*
 * Hello World
 * by Mike Schwörer 2014
*/

program example : display[0, 0]
	var stack<int>[12] buffer;
	begin
		out buffer.count();
		buffer.push(four());
		out buffer.count();
		buffer.push(four() + four());
		out buffer.count();
		buffer.push(four() * four() - 1);
		out buffer.count();
		buffer.push(four() * four());
		out buffer.count();
		buffer.push(four()*4+3);
		out buffer.count();
		buffer.push(10*four() + 2);
		out buffer.count();



		quit;
	end
	 
	int four()
	begin
	 return 4;
	end
end