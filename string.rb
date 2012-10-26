# p013expint.rb  
def say_goodnight(name)  
  result = "Good night, #{name}"  
  return result  
end  
puts say_goodnight('Satish')  
  
# modified program  
def say_goodnight2(name)  
   "Good night, #{name}".reverse  
end  

puts say_goodnight2('Talim')

puts "Upper case".upcase

puts "Lower case".downcase

# puts String.methods.sort
# puts String.instance_methods.sort

names1 = [ 'ann', 'richard', 'william', 'susan', 'pat' ]  
puts names1[0] # ann  
puts names1[3] # susan
  
# this is the same:  
names2 = %w{ann richard william susan pat}  
puts names2[0] # ann  
puts names2[3] # susan