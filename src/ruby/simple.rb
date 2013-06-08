module Expression
    def inspect
        "«#{self}»"#.encoding
    end
end

class Number < Struct.new(:value)
    include Expression

    def to_s
        value.to_s
    end
end

class Add < Struct.new(:left, :right)
    include Expression

    def to_s
        "#{left} + #{right}"
    end
end

class Multiply < Struct.new(:left, :right)
    include Expression

    def to_s
        "#{left} * #{right}"
    end
end

puts Add.new(
    Multiply.new(Number.new(1), Number.new(2)),
    Multiply.new(Number.new(3), Number.new(4))
).inspect

puts Number.new(123).inspect

