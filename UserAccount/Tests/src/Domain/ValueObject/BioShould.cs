using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Tests.src.Domain.ValueObject
{
    public class BioShould
    {
          [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var bio = "Esta es una nueva biografia";
            var newbio = Bio.Create(bio);

            newbio.Should().BeOfType<Result<Bio>>();
            newbio.Value.Should().BeOfType<Bio>();

        }
        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var bio = "ivancorlli1230509234908corlliherrandoivanylasjkfdhakhlgkjhdglkjshdfgkshdfgklhsdfgkshdfgkjshdfgkljshdgkljsdhfgksdhfglksdhfgskdfhgskldfjhgslkjdhglskdjfhglskdfhgskldfjhgslkdjfhgsdofpgjvioefhn j [ag[a dpsf asp[d fas[diufa[isdjf a[pfoias pi44934t aslkdjhfaksljdhfaskljdhfalksdhfalksjdhfaksdhfosfresnosgmail.com";
            var newbio = Bio.Create(bio);

            newbio.IsSuccess.Should().BeFalse();
            newbio.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

    }
}