require 'net/http'

uri = URI('http://zhangyue.info')
res = Net::HTTP.get_response(uri)
puts res.body