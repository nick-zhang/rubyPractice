def meth_three
  100.times do |num|
    square = num * num
    return num, square if square > 1000
  end
end

puts meth_three

num, square = meth_three

puts "num, square #{num} #{square}"



def multiple_parameter(a, b, c)
  puts "I was passed #{a}, #{b}, #{c}"
end

puts multiple_parameter(1, 2, 3)

puts multiple_parameter(*['a', 'b', 'c'])