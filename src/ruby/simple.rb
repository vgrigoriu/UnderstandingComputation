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

    def reduce
        if left.reducible?
            Add.new(left.reduce, right)
        elsif right.reducible?
            Add.new(left, right.reduce)
        else
            Number.new(left.value + right.value)
        end
    end

    def to_s
        "#{left} + #{right}"
    end
end

class Multiply < Struct.new(:left, :right)
    include Expression

    def reducible?
        true
    end

    def reduce
        if left.reducible?
            Multiply.new(left.reduce, right)
        elsif right.reducible?
            Multiply.new(left, right.reduce)
        else
            Number.new(left.value * right.value)
        end
    end

    def to_s
        "#{left} * #{right}"
    end
end

class Reducible < Struct.new(:reduced?, :reducible?)
    # def init(reducible)
    #     reducible? = reducible
    #     reduced = false
    # end

    def reduce
        Reducible.new(true, reducible?)
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

    def test_multiply_is_reducible
        multiply = Multiply.new(nil, nil)
        assert_equal(true, multiply.reducible?)
    end

    def test_add_reduces_left_argument_if_reducible
        add = Add.new(Reducible.new(false, true), Reducible.new(false, true))
        reduced_add = add.reduce
        assert_equal(true, reduced_add.left.reduced?)
        assert_equal(false, reduced_add.right.reduced?)
    end

    def test_add_reduces_right_argument_if_reducible_and_left_one_not
        add = Add.new(Reducible.new(false, false), Reducible.new(false, true))
        reduced_add = add.reduce
        assert_equal(false, reduced_add.left.reduced?)
        assert_equal(true, reduced_add.right.reduced?)
    end

    def test_add_reduces_to_sum_of_values
        add = Add.new(Number.new(123), Number.new(2))
        assert_equal(125, add.reduce.value)
    end

    # todo: add test for Multiply.reduce
end
