def meth_three
  100.times do |num|
    square = num * num
    return num, square if square > 1000
  end
end

puts meth_three
