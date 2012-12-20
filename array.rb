# var1 = []  
# var1.push("a")
# var1.push("b")
# var1.push("c")
# 
# var1.each do |item|
#   puts item
# end


array2 = ["ant", "bee", "cat", "dog", "elk"]
puts array2[0, 2]

puts "*****"
puts array2
puts "array2 0: #{array2[0]}"
array2[1, 0] = ""


array3 = %w{this is an array}
puts array3 