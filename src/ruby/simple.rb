require "test/unit"

module Expression
    def inspect
        "«#{self}»"#.encoding
    end
end

class Number < Struct.new(:value)
    include Expression

    def reducible?
        false
    end

    def to_s
        value.to_s
    end
end

class Add < Struct.new(:left, :right)
    include Expression

    def reducible?
        true
    end

    def to_s
        "#{left} + #{right}"
    end
end

class Multiply < Struct.new(:left, :right)
    include Expression

    def reduciblr?
        true
    end

    def to_s
        "#{left} * #{right}"
    end
end

class TestExpressions < Test::Unit::TestCase
    def test_inspect_number
        assert_equal('«14»', Number.new(14).inspect)
    end

    def test_inspect_add_numbers
        add = Add.new(Number.new(12), Number.new(21))
        assert_equal('«12 + 21»', add.inspect)
    end

    def test_inspect_multiply_numbers
        multiply = Multiply.new(Number.new(17), Number.new(71))
        assert_equal('«17 * 71»', multiply.inspect)
    end

    def test_inspect_complex_expression
        expression = Add.new(
            Multiply.new(Number.new(1), Number.new(2)),
            Multiply.new(Number.new(3), Number.new(4)))
        assert_equal('«1 * 2 + 3 * 4»', expression.inspect)
    end

    def test_number_is_not_reducible
        number = Number.new(12321)
        assert_equal(false, number.reducible?)
    end  
end
