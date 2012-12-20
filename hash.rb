# hash.rb

hash1 = {}
array1 = %w(this is good)
array2 = %w(this is bad)

hash1['a'] = array1
hash1['b'] = array2

puts "Pair count in the hash: #{hash1.count}"
 
hash1.each_key do |key|
  puts "key #{key}"
  puts hash1[key]
end