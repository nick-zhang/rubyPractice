# var1 = []  
# var1.push("a")
# var1.push("b")
# var1.push("c")
# 
# var1.each do |item|
#   puts item
# end

a = (1..10).to_a
puts "1 - 10: #{a}"

array2 = ["ant", "bee", "cat", "dog", "elk"]
puts array2[0, 2]

puts "*****"
puts array2
puts "array2 0: #{array2[0]}"
array2[1, 0] = ""


array3 = %w{this is an array}

puts "array3 count length > 4: #{array3.count {|item | item.length > 4} }"
puts array3 

#inject
summary = [1,3,5,7].inject(0) do |sum, item| 
  sum + item 
  end

puts "Inject for summary:#{summary}"

multiply = [1,3,5,7].inject(1) {|mul, item| mul * item}
puts "Inject for multiply:#{multiply}"
