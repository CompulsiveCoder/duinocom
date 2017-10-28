#TEST_CATEGORY=$1

# TODO: Is this needed? Currently all tests are run, and the category is ignored. Remove or reimplement.
#if [ -z "$TEST_CATEGORY" ]; then
#    TEST_CATEGORY="Unit"
#fi

#echo "Tests: $TEST_CATEGORY"

sh build.sh

docker run -i -v /var/run/docker.sock:/var/run/docker.sock -v $PWD:/duinocom compulsivecoder/ubuntu-mono /bin/bash -c "cd /duinocom && sh build.sh && sh test-all.sh" #$TEST_CATEGORY"
