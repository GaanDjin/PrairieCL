using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieCL.OpenCL
{

    /// <summary>
    /// Reference from the OpenCL Headers used to create this wrapper.
    /// Unused.
    /// </summary>
    internal class Constants
    {
        //const int CL_TARGET_OPENCL_VERSION = 300;


        ///* OpenCL Version */
        //const int CL_VERSION_3_0 = 1;
        //const int CL_VERSION_2_2 = 1;
        //const int CL_VERSION_2_1 = 1;
        //const int CL_VERSION_2_0 = 1;
        //const int CL_VERSION_1_2 = 1;
        //const int CL_VERSION_1_1 = 1;
        //const int CL_VERSION_1_0 = 1;



        ////#if defined(_WIN32)
        ////    #if !defined(CL_API_ENTRY)
        ////        const int CL_API_ENTRY
        ////    #endif
        ////    #if !defined(CL_API_CALL)
        ////        const int CL_API_CALL     __stdcall
        ////    #endif
        ////    #if !defined(CL_CALLBACK)
        ////        const int CL_CALLBACK     __stdcall
        ////    #endif
        ////#endif

        ///*
        // * Deprecation flags refer to the last version of the header in which the
        // * feature was not deprecated.
        // *
        // * E.g. VERSION_1_1_DEPRECATED means the feature is present in 1.1 without
        // * deprecation but is deprecated in versions later than 1.1.
        // */

        ////#ifndef CL_API_SUFFIX_USER
        ////const int CL_API_SUFFIX_USER
        ////#endif

        ////#ifndef CL_API_PREFIX_USER
        ////const int CL_API_PREFIX_USER
        ////#endif

        ////const int CL_API_SUFFIX_COMMON CL_API_SUFFIX_USER
        ////const int CL_API_PREFIX_COMMON CL_API_PREFIX_USER

        ////const int  CL_API_SUFFIX_COMMON
        ////const int CL_API_SUFFIX__VERSION_1_1 CL_API_SUFFIX_COMMON
        ////const int  CL_API_SUFFIX_COMMON
        ////const int CL_API_SUFFIX__VERSION_2_0 CL_API_SUFFIX_COMMON
        ////const int  CL_API_SUFFIX_COMMON
        ////const int CL_API_SUFFIX__VERSION_2_2 CL_API_SUFFIX_COMMON
        ////const int CL_API_SUFFIX__VERSION_3_0 CL_API_SUFFIX_COMMON
        ////const int CL_API_SUFFIX__EXPERIMENTAL CL_API_SUFFIX_COMMON


        ////#ifdef __GNUC__
        ////  const int CL_API_SUFFIX_DEPRECATED __attribute__((deprecated))
        ////  const int CL_API_PREFIX_DEPRECATED
        ////#elif defined(_WIN32)
        ////  const int CL_API_SUFFIX_DEPRECATED
        ////  const int CL_API_PREFIX_DEPRECATED __declspec(deprecated)
        ////#else
        ////  const int CL_API_SUFFIX_DEPRECATED
        ////  const int CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_1_0_APIS
        ////    const int CL_API_SUFFIX__VERSION_1_0_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_1_0_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_1_0_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_1_0_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_1_1_APIS
        ////    const int CL_API_SUFFIX__VERSION_1_1_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_1_1_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_1_1_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_1_1_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_1_2_APIS
        ////    const int CL_API_SUFFIX__VERSION_1_2_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_1_2_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_1_2_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_1_2_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        //// #endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_2_0_APIS
        ////    const int CL_API_SUFFIX__VERSION_2_0_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_2_0_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_2_0_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_2_0_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_2_1_APIS
        ////    const int CL_API_SUFFIX__VERSION_2_1_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_2_1_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_2_1_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_2_1_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#ifdef CL_USE_DEPRECATED_OPENCL_2_2_APIS
        ////    const int CL_API_SUFFIX__VERSION_2_2_DEPRECATED CL_API_SUFFIX_COMMON
        ////    const int CL_API_PREFIX__VERSION_2_2_DEPRECATED CL_API_PREFIX_COMMON
        ////#else
        ////    const int CL_API_SUFFIX__VERSION_2_2_DEPRECATED CL_API_SUFFIX_COMMON CL_API_SUFFIX_DEPRECATED
        ////    const int CL_API_PREFIX__VERSION_2_2_DEPRECATED CL_API_PREFIX_COMMON CL_API_PREFIX_DEPRECATED
        ////#endif

        ////#if (defined (_WIN32) && defined(_MSC_VER))

        ////#if defined(__clang__)
        ////#pragma clang diagnostic push
        ////#pragma clang diagnostic ignored "-Wlanguage-extension-token"
        ////#endif

        ///* intptr_t is used in cl.h and provided by stddef.h in Visual C++, but not in clang */
        ///* stdint.h was missing before Visual Studio 2010, include it for later versions and for clang */
        ////#if defined(__clang__) || _MSC_VER >= 1600
        ////    #include <stdint.h>
        ////#endif

        ///* scalar types  */
        ////typedef signed   __int8         byte;
        ////typedef unsigned __int8         byte;
        ////typedef signed   __int16        short;
        ////typedef unsigned __int16        ushort;
        ////typedef signed   __int32        int;
        ////typedef unsigned __int32        uint;
        ////typedef signed   __int64        long;
        ////typedef unsigned __int64        ulong;

        ////typedef unsigned __int16        ushort;
        ////typedef float                   float;
        ////typedef double                  double;

        ////#if defined(__clang__)
        ////#pragma clang diagnostic pop
        ////#endif

        ///* Macro names and corresponding values defined by OpenCL */
        //const int CL_CHAR_BIT = 8;
        //const int CL_SCHAR_MAX = 127;
        //const int CL_SCHAR_MIN = (-127 - 1);
        //const int CL_CHAR_MAX = CL_SCHAR_MAX;
        //const int CL_CHAR_MIN = CL_SCHAR_MIN;
        //const int CL_UCHAR_MAX = 255;
        //const int CL_SHRT_MAX = 32767;
        //const int CL_SHRT_MIN = (-32767 - 1);
        //const int CL_USHRT_MAX = 65535;
        //const int CL_INT_MAX = 2147483647;
        //const int CL_INT_MIN = (-2147483647 - 1);
        //const uint CL_UINT_MAX = 0xffffffff;
        //const long CL_LONG_MAX = (long)(0x7FFFFFFFFFFFFFFF);
        //const long CL_LONG_MIN = (long)(-0x7FFFFFFFFFFFFFFF - 1);
        //const ulong CL_ULONG_MAX = (ulong)(0xFFFFFFFFFFFFFFFF);

        //const int CL_FLT_DIG = 6;
        //const int CL_FLT_MANT_DIG = 24;
        //const int CL_FLT_MAX_10_EXP = +38;
        //const int CL_FLT_MAX_EXP = +128;
        //const int CL_FLT_MIN_10_EXP = -37;
        //const int CL_FLT_MIN_EXP = -125;
        //const int CL_FLT_RADIX = 2;
        //const float CL_FLT_MAX = 340282346638528859811704183484516925440.0f;
        //const float CL_FLT_MIN = 1.175494350822287507969e-38f;
        //const float CL_FLT_EPSILON = 1.1920928955078125e-7f;

        //const int CL_HALF_DIG = 3;
        //const int CL_HALF_MANT_DIG = 11;
        //const int CL_HALF_MAX_10_EXP = +4;
        //const int CL_HALF_MAX_EXP = +16;
        //const int CL_HALF_MIN_10_EXP = -4;
        //const int CL_HALF_MIN_EXP = -13;
        //const int CL_HALF_RADIX = 2;
        //const float CL_HALF_MAX = 65504.0f;
        //const float CL_HALF_MIN = 6.103515625e-05f;
        //const float CL_HALF_EPSILON = 9.765625e-04f;

        //const int CL_DBL_DIG = 15;
        //const int CL_DBL_MANT_DIG = 53;
        //const int CL_DBL_MAX_10_EXP = +308;
        //const int CL_DBL_MAX_EXP = +1024;
        //const int CL_DBL_MIN_10_EXP = -307;
        //const int CL_DBL_MIN_EXP = -1021;
        //const int CL_DBL_RADIX = 2;
        //const double CL_DBL_MAX = 1.7976931348623158e+308;
        //const double CL_DBL_MIN = 2.225073858507201383090e-308;
        //const double CL_DBL_EPSILON = 2.220446049250313080847e-16;

        //const double CL_M_E = 2.7182818284590452354;
        //const double CL_M_LOG2E = 1.4426950408889634074;
        //const double CL_M_LOG10E = 0.43429448190325182765;
        //const double CL_M_LN2 = 0.69314718055994530942;
        //const double CL_M_LN10 = 2.30258509299404568402;
        //const double CL_M_PI = 3.14159265358979323846;
        //const double CL_M_PI_2 = 1.57079632679489661923;
        //const double CL_M_PI_4 = 0.78539816339744830962;
        //const double CL_M_1_PI = 0.31830988618379067154;
        //const double CL_M_2_PI = 0.63661977236758134308;
        //const double CL_M_2_SQRTPI = 1.12837916709551257390;
        //const double CL_M_SQRT2 = 1.41421356237309504880;
        //const double CL_M_SQRT1_2 = 0.70710678118654752440;

        //const float CL_M_E_F = 2.718281828f;
        //const float CL_M_LOG2E_F = 1.442695041f;
        //const float CL_M_LOG10E_F = 0.434294482f;
        //const float CL_M_LN2_F = 0.693147181f;
        //const float CL_M_LN10_F = 2.302585093f;
        //const float CL_M_PI_F = 3.141592654f;
        //const float CL_M_PI_2_F = 1.570796327f;
        //const float CL_M_PI_4_F = 0.785398163f;
        //const float CL_M_1_PI_F = 0.318309886f;
        //const float CL_M_2_PI_F = 0.636619772f;
        //const float CL_M_2_SQRTPI_F = 1.128379167f;
        //const float CL_M_SQRT2_F = 1.414213562f;
        //const float CL_M_SQRT1_2_F = 0.707106781f;

        //const float CL_NAN = float.NaN; //(CL_INFINITY - CL_INFINITY);
        //const float CL_HUGE_VALF = ((float)1e50);
        //const float CL_HUGE_VAL = ((double)1e500);
        //const float CL_MAXFLOAT = CL_FLT_MAX;
        //const float CL_INFINITY = float.PositiveInfinity; // CL_HUGE_VALF;

        //const float CL_HUGE_VALF = ((float)1e50);
        //const double CL_HUGE_VAL = ((double)1e500);


        /*
         * Vector types
         *
         *  Note:   OpenCL requires that all types be naturally aligned.
         *          This means that vector types must be naturally aligned.
         *          For example, a vector of four floats must be aligned to
         *          a 16 byte boundary (calculated as 4 * the natural 4-byte
         *          alignment of the float).  The alignment qualifiers here
         *          will only function properly if your compiler supports them
         *          and if you don't actively work to defeat them.  For example,
         *          in order for a cl_float4 to be 16 byte aligned in a struct,
         *          the start of the struct must itself be 16-byte aligned.
         *
         *          Maintaining proper alignment is the user's responsibility.
         */

        //        /* Define basic vector types */
        //#if defined( __VEC__ )
        //#if !defined(__clang__)
        //# include <altivec.h>   /* may be omitted depending on compiler. AltiVec spec provides no way to detect whether the header is required. */
        //#endif
        //   typedef __vector unsigned char     __cl_uchar16;
        //   typedef __vector signed char       __cl_char16;
        //   typedef __vector unsigned short    __cl_ushort8;
        //   typedef __vector signed short      __cl_short8;
        //   typedef __vector unsigned int      __cl_uint4;
        //   typedef __vector signed int        __cl_int4;
        //   typedef __vector float             __cl_float4;
        //const int __CL_UCHAR16__  1
        //const int __CL_CHAR16__   1
        //const int __CL_USHORT8__  1
        //const int __CL_SHORT8__   1
        //const int __CL_UINT4__    1
        //const int __CL_INT4__     1
        //const int __CL_FLOAT4__   1
        //#endif

        //#if defined( __SSE__ )
        //#if defined( __MINGW64__ )
        //# include <intrin.h>
        //#else
        //# include <xmmintrin.h>
        //#endif
        //#if defined( __GNUC__ )
        //        typedef float __cl_float4   __attribute__((vector_size(16)));
        //#else
        //        typedef __m128 __cl_float4;
        //#endif
        //const int __CL_FLOAT4__   1
        //#endif

        //#if defined( __SSE2__ )
        //#if defined( __MINGW64__ )
        //# include <intrin.h>
        //#else
        //# include <emmintrin.h>
        //#endif
        //#if defined( __GNUC__ )
        //        typedef byte    __cl_uchar16    __attribute__((vector_size(16)));
        //        typedef byte     __cl_char16     __attribute__((vector_size(16)));
        //        typedef ushort   __cl_ushort8    __attribute__((vector_size(16)));
        //        typedef short    __cl_short8     __attribute__((vector_size(16)));
        //        typedef uint     __cl_uint4      __attribute__((vector_size(16)));
        //        typedef int      __cl_int4       __attribute__((vector_size(16)));
        //        typedef ulong    __cl_ulong2     __attribute__((vector_size(16)));
        //        typedef long     __cl_long2      __attribute__((vector_size(16)));
        //        typedef double   __cl_double2    __attribute__((vector_size(16)));
        //#else
        //        typedef __m128i __cl_uchar16;
        //        typedef __m128i __cl_char16;
        //        typedef __m128i __cl_ushort8;
        //        typedef __m128i __cl_short8;
        //        typedef __m128i __cl_uint4;
        //        typedef __m128i __cl_int4;
        //        typedef __m128i __cl_ulong2;
        //        typedef __m128i __cl_long2;
        //        typedef __m128d __cl_double2;
        //#endif
        //const int __CL_UCHAR16__  1
        //const int __CL_CHAR16__   1
        //const int __CL_USHORT8__  1
        //const int __CL_SHORT8__   1
        //const int __CL_INT4__     1
        //const int __CL_UINT4__    1
        //const int __CL_ULONG2__   1
        //const int __CL_LONG2__    1
        //const int __CL_DOUBLE2__  1
        //#endif

        //#if defined( __MMX__ )
        //# include <mmintrin.h>
        //#if defined( __GNUC__ )
        //        typedef byte    __cl_uchar8     __attribute__((vector_size(8)));
        //        typedef byte     __cl_char8      __attribute__((vector_size(8)));
        //        typedef ushort   __cl_ushort4    __attribute__((vector_size(8)));
        //        typedef short    __cl_short4     __attribute__((vector_size(8)));
        //        typedef uint     __cl_uint2      __attribute__((vector_size(8)));
        //        typedef int      __cl_int2       __attribute__((vector_size(8)));
        //        typedef ulong    __cl_ulong1     __attribute__((vector_size(8)));
        //        typedef long     __cl_long1      __attribute__((vector_size(8)));
        //        typedef float    __cl_float2     __attribute__((vector_size(8)));
        //#else
        //        typedef __m64       __cl_uchar8;
        //        typedef __m64       __cl_char8;
        //        typedef __m64       __cl_ushort4;
        //        typedef __m64       __cl_short4;
        //        typedef __m64       __cl_uint2;
        //        typedef __m64       __cl_int2;
        //        typedef __m64       __cl_ulong1;
        //        typedef __m64       __cl_long1;
        //        typedef __m64       __cl_float2;
        //#endif
        //const int __CL_UCHAR8__   1
        //const int __CL_CHAR8__    1
        //const int __CL_USHORT4__  1
        //const int __CL_SHORT4__   1
        //const int __CL_INT2__     1
        //const int __CL_UINT2__    1
        //const int __CL_ULONG1__   1
        //const int __CL_LONG1__    1
        //const int __CL_FLOAT2__   1
        //#endif

        //#if defined( __AVX__ )
        //#if defined( __MINGW64__ )
        //# include <intrin.h>
        //#else
        //# include <immintrin.h>
        //#endif
        //#if defined( __GNUC__ )
        //        typedef float    __cl_float8     __attribute__((vector_size(32)));
        //        typedef double   __cl_double4    __attribute__((vector_size(32)));
        //#else
        //        typedef __m256      __cl_float8;
        //        typedef __m256d     __cl_double4;
        //#endif
        //const int __CL_FLOAT8__   1
        //const int __CL_DOUBLE4__  1
        //#endif

        //        /* Define capabilities for anonymous struct members. */
        //#if !defined(__cplusplus) && defined(__STDC_VERSION__) && __STDC_VERSION__ >= 201112L
        //const int __CL_HAS_ANON_STRUCT__ 1
        //const int __CL_ANON_STRUCT__
        //#elif defined(_WIN32) && defined(_MSC_VER) && !defined(__STDC__)
        //const int __CL_HAS_ANON_STRUCT__ 1
        //const int __CL_ANON_STRUCT__
        //#elif defined(__GNUC__) && ! defined(__STRICT_ANSI__)
        //const int __CL_HAS_ANON_STRUCT__ 1
        //const int __CL_ANON_STRUCT__ __extension__
        //#else
        //const int __CL_HAS_ANON_STRUCT__ 0
        //const int __CL_ANON_STRUCT__
        //#endif

        //#if defined(_WIN32) && defined(_MSC_VER) && __CL_HAS_ANON_STRUCT__
        //   /* Disable warning C4201: nonstandard extension used : nameless struct/union */
        //#pragma warning( push )
        //#pragma warning( disable : 4201 )
        //#endif

        //        /* Define alignment keys */
        //#if defined( __GNUC__ ) || defined(__INTEGRITY)
        //const int CL_ALIGNED(_x)          __attribute__ ((aligned(_x)))
        //#elif defined( _WIN32) && (_MSC_VER)
        //    /* Alignment keys neutered on windows because MSVC can't swallow function arguments with alignment requirements     */
        //    /* http://msdn.microsoft.com/en-us/library/373ak2y1%28VS.71%29.aspx                                                 */
        //    /* #include <crtdefs.h>                                                                                             */
        //    /* const int CL_ALIGNED(_x)          _CRT_ALIGN(_x)                                                                   */
        //const int CL_ALIGNED(_x)
        //#else
        //#warning  Need to implement some method to align data here
        //const int CL_ALIGNED(_x)
        //#endif

        //        /* Indicate whether .xyzw, .s0123 and .hi.lo are supported */
        //#if __CL_HAS_ANON_STRUCT__
        //        /* .xyzw and .s0123...{f|F} are supported */
        //const int CL_HAS_NAMED_VECTOR_FIELDS 1
        //        /* .hi and .lo are supported */
        //const int CL_HAS_HI_LO_VECTOR_FIELDS 1
        //#endif

        /* Define cl_vector types */

        //        /* ---- cl_charn ---- */
        //        typedef union
        //        {
        //            byte CL_ALIGNED(2) s[2];
        //#if __CL_HAS_ANON_STRUCT__
        //   __CL_ANON_STRUCT__ struct{ byte x, y;
        //    };
        //    __CL_ANON_STRUCT__ struct{ byte s0, s1;
        //};
        //__CL_ANON_STRUCT__ struct{ byte lo, hi; };
        //#endif
        //#if defined( __CL_CHAR2__)
        //    __cl_char2     v2;
        //#endif
        //}cl_char2;

        //typedef union
        //{
        //    byte CL_ALIGNED(4) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_char2 lo, hi; };
        //#endif
        //#if defined( __CL_CHAR2__)
        //    __cl_char2     v2[2];
        //#endif
        //#if defined( __CL_CHAR4__)
        //    __cl_char4     v4;
        //#endif
        //}cl_char4;

        ///* cl_char3 is identical in size, alignment and behavior to cl_char4. See section 6.1.5. */
        //typedef cl_char4  cl_char3;

        //typedef union
        //{
        //    byte CL_ALIGNED(8) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_char4 lo, hi; };
        //#endif
        //#if defined( __CL_CHAR2__)
        //    __cl_char2     v2[4];
        //#endif
        //#if defined( __CL_CHAR4__)
        //    __cl_char4     v4[2];
        //#endif
        //#if defined( __CL_CHAR8__ )
        //    __cl_char8     v8;
        //#endif
        //}cl_char8;

        //typedef union
        //{
        //    byte CL_ALIGNED(16) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_char8 lo, hi; };
        //#endif
        //#if defined( __CL_CHAR2__)
        //    __cl_char2     v2[8];
        //#endif
        //#if defined( __CL_CHAR4__)
        //    __cl_char4     v4[4];
        //#endif
        //#if defined( __CL_CHAR8__ )
        //    __cl_char8     v8[2];
        //#endif
        //#if defined( __CL_CHAR16__ )
        //    __cl_char16    v16;
        //#endif
        //}cl_char16;


        ///* ---- cl_ucharn ---- */
        //typedef union
        //{
        //    byte CL_ALIGNED(2) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1; };
        //__CL_ANON_STRUCT__ struct{ byte lo, hi; };
        //#endif
        //#if defined( __cl_uchar2__)
        //    __cl_uchar2     v2;
        //#endif
        //}cl_uchar2;

        //typedef union
        //{
        //    byte CL_ALIGNED(4) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_uchar2 lo, hi; };
        //#endif
        //#if defined( __CL_UCHAR2__)
        //    __cl_uchar2     v2[2];
        //#endif
        //#if defined( __CL_UCHAR4__)
        //    __cl_uchar4     v4;
        //#endif
        //}cl_uchar4;

        ///* cl_uchar3 is identical in size, alignment and behavior to cl_uchar4. See section 6.1.5. */
        //typedef cl_uchar4  cl_uchar3;

        //typedef union
        //{
        //    byte CL_ALIGNED(8) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_uchar4 lo, hi; };
        //#endif
        //#if defined( __CL_UCHAR2__)
        //    __cl_uchar2     v2[4];
        //#endif
        //#if defined( __CL_UCHAR4__)
        //    __cl_uchar4     v4[2];
        //#endif
        //#if defined( __CL_UCHAR8__ )
        //    __cl_uchar8     v8;
        //#endif
        //}cl_uchar8;

        //typedef union
        //{
        //    byte CL_ALIGNED(16) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ byte x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ byte s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_uchar8 lo, hi; };
        //#endif
        //#if defined( __CL_UCHAR2__)
        //    __cl_uchar2     v2[8];
        //#endif
        //#if defined( __CL_UCHAR4__)
        //    __cl_uchar4     v4[4];
        //#endif
        //#if defined( __CL_UCHAR8__ )
        //    __cl_uchar8     v8[2];
        //#endif
        //#if defined( __CL_UCHAR16__ )
        //    __cl_uchar16    v16;
        //#endif
        //}cl_uchar16;


        ///* ---- cl_shortn ---- */
        //typedef union
        //{
        //    short CL_ALIGNED(4) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ short x, y; };
        //__CL_ANON_STRUCT__ struct{ short s0, s1; };
        //__CL_ANON_STRUCT__ struct{ short lo, hi; };
        //#endif
        //#if defined( __CL_SHORT2__)
        //    __cl_short2     v2;
        //#endif
        //}cl_short2;

        //typedef union
        //{
        //    short CL_ALIGNED(8) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ short x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ short s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_short2 lo, hi; };
        //#endif
        //#if defined( __CL_SHORT2__)
        //    __cl_short2     v2[2];
        //#endif
        //#if defined( __CL_SHORT4__)
        //    __cl_short4     v4;
        //#endif
        //}cl_short4;

        ///* cl_short3 is identical in size, alignment and behavior to cl_short4. See section 6.1.5. */
        //typedef cl_short4  cl_short3;

        //typedef union
        //{
        //    short CL_ALIGNED(16) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ short x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ short s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_short4 lo, hi; };
        //#endif
        //#if defined( __CL_SHORT2__)
        //    __cl_short2     v2[4];
        //#endif
        //#if defined( __CL_SHORT4__)
        //    __cl_short4     v4[2];
        //#endif
        //#if defined( __CL_SHORT8__ )
        //    __cl_short8     v8;
        //#endif
        //}cl_short8;

        //typedef union
        //{
        //    short CL_ALIGNED(32) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ short x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ short s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_short8 lo, hi; };
        //#endif
        //#if defined( __CL_SHORT2__)
        //    __cl_short2     v2[8];
        //#endif
        //#if defined( __CL_SHORT4__)
        //    __cl_short4     v4[4];
        //#endif
        //#if defined( __CL_SHORT8__ )
        //    __cl_short8     v8[2];
        //#endif
        //#if defined( __CL_SHORT16__ )
        //    __cl_short16    v16;
        //#endif
        //}cl_short16;


        ///* ---- cl_ushortn ---- */
        //typedef union
        //{
        //    ushort CL_ALIGNED(4) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1; };
        //__CL_ANON_STRUCT__ struct{ ushort lo, hi; };
        //#endif
        //#if defined( __CL_USHORT2__)
        //    __cl_ushort2     v2;
        //#endif
        //}cl_ushort2;

        //typedef union
        //{
        //    ushort CL_ALIGNED(8) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_ushort2 lo, hi; };
        //#endif
        //#if defined( __CL_USHORT2__)
        //    __cl_ushort2     v2[2];
        //#endif
        //#if defined( __CL_USHORT4__)
        //    __cl_ushort4     v4;
        //#endif
        //}cl_ushort4;

        ///* cl_ushort3 is identical in size, alignment and behavior to cl_ushort4. See section 6.1.5. */
        //typedef cl_ushort4  cl_ushort3;

        //typedef union
        //{
        //    ushort CL_ALIGNED(16) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_ushort4 lo, hi; };
        //#endif
        //#if defined( __CL_USHORT2__)
        //    __cl_ushort2     v2[4];
        //#endif
        //#if defined( __CL_USHORT4__)
        //    __cl_ushort4     v4[2];
        //#endif
        //#if defined( __CL_USHORT8__ )
        //    __cl_ushort8     v8;
        //#endif
        //}cl_ushort8;

        //typedef union
        //{
        //    ushort CL_ALIGNED(32) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_ushort8 lo, hi; };
        //#endif
        //#if defined( __CL_USHORT2__)
        //    __cl_ushort2     v2[8];
        //#endif
        //#if defined( __CL_USHORT4__)
        //    __cl_ushort4     v4[4];
        //#endif
        //#if defined( __CL_USHORT8__ )
        //    __cl_ushort8     v8[2];
        //#endif
        //#if defined( __CL_USHORT16__ )
        //    __cl_ushort16    v16;
        //#endif
        //}cl_ushort16;


        ///* ---- cl_halfn ---- */
        //typedef union
        //{
        //    ushort CL_ALIGNED(4) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1; };
        //__CL_ANON_STRUCT__ struct{ ushort lo, hi; };
        //#endif
        //#if defined( __CL_HALF2__)
        //    __cl_half2     v2;
        //#endif
        //}cl_half2;

        //typedef union
        //{
        //    ushort CL_ALIGNED(8) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_half2 lo, hi; };
        //#endif
        //#if defined( __CL_HALF2__)
        //    __cl_half2     v2[2];
        //#endif
        //#if defined( __CL_HALF4__)
        //    __cl_half4     v4;
        //#endif
        //}cl_half4;

        ///* cl_half3 is identical in size, alignment and behavior to cl_half4. See section 6.1.5. */
        //typedef cl_half4  cl_half3;

        //typedef union
        //{
        //    ushort CL_ALIGNED(16) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_half4 lo, hi; };
        //#endif
        //#if defined( __CL_HALF2__)
        //    __cl_half2     v2[4];
        //#endif
        //#if defined( __CL_HALF4__)
        //    __cl_half4     v4[2];
        //#endif
        //#if defined( __CL_HALF8__ )
        //    __cl_half8     v8;
        //#endif
        //}cl_half8;

        //typedef union
        //{
        //    ushort CL_ALIGNED(32) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ushort x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ ushort s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_half8 lo, hi; };
        //#endif
        //#if defined( __CL_HALF2__)
        //    __cl_half2     v2[8];
        //#endif
        //#if defined( __CL_HALF4__)
        //    __cl_half4     v4[4];
        //#endif
        //#if defined( __CL_HALF8__ )
        //    __cl_half8     v8[2];
        //#endif
        //#if defined( __CL_HALF16__ )
        //    __cl_half16    v16;
        //#endif
        //}cl_half16;

        ///* ---- cl_intn ---- */
        //typedef union
        //{
        //    int CL_ALIGNED(8) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ int x, y; };
        //__CL_ANON_STRUCT__ struct{ int s0, s1; };
        //__CL_ANON_STRUCT__ struct{ int lo, hi; };
        //#endif
        //#if defined( __CL_INT2__)
        //    __cl_int2     v2;
        //#endif
        //}cl_int2;

        //typedef union
        //{
        //    int CL_ALIGNED(16) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ int x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ int s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_int2 lo, hi; };
        //#endif
        //#if defined( __CL_INT2__)
        //    __cl_int2     v2[2];
        //#endif
        //#if defined( __CL_INT4__)
        //    __cl_int4     v4;
        //#endif
        //}cl_int4;

        ///* cl_int3 is identical in size, alignment and behavior to cl_int4. See section 6.1.5. */
        //typedef cl_int4  cl_int3;

        //typedef union
        //{
        //    int CL_ALIGNED(32) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ int x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ int s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_int4 lo, hi; };
        //#endif
        //#if defined( __CL_INT2__)
        //    __cl_int2     v2[4];
        //#endif
        //#if defined( __CL_INT4__)
        //    __cl_int4     v4[2];
        //#endif
        //#if defined( __CL_INT8__ )
        //    __cl_int8     v8;
        //#endif
        //}cl_int8;

        //typedef union
        //{
        //    int CL_ALIGNED(64) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ int x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ int s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_int8 lo, hi; };
        //#endif
        //#if defined( __CL_INT2__)
        //    __cl_int2     v2[8];
        //#endif
        //#if defined( __CL_INT4__)
        //    __cl_int4     v4[4];
        //#endif
        //#if defined( __CL_INT8__ )
        //    __cl_int8     v8[2];
        //#endif
        //#if defined( __CL_INT16__ )
        //    __cl_int16    v16;
        //#endif
        //}cl_int16;


        ///* ---- cl_uintn ---- */
        //typedef union
        //{
        //    uint CL_ALIGNED(8) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ uint x, y; };
        //__CL_ANON_STRUCT__ struct{ uint s0, s1; };
        //__CL_ANON_STRUCT__ struct{ uint lo, hi; };
        //#endif
        //#if defined( __CL_UINT2__)
        //    __cl_uint2     v2;
        //#endif
        //}cl_uint2;

        //typedef union
        //{
        //    uint CL_ALIGNED(16) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ uint x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ uint s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_uint2 lo, hi; };
        //#endif
        //#if defined( __CL_UINT2__)
        //    __cl_uint2     v2[2];
        //#endif
        //#if defined( __CL_UINT4__)
        //    __cl_uint4     v4;
        //#endif
        //}cl_uint4;

        ///* cl_uint3 is identical in size, alignment and behavior to cl_uint4. See section 6.1.5. */
        //typedef cl_uint4  cl_uint3;

        //typedef union
        //{
        //    uint CL_ALIGNED(32) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ uint x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ uint s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_uint4 lo, hi; };
        //#endif
        //#if defined( __CL_UINT2__)
        //    __cl_uint2     v2[4];
        //#endif
        //#if defined( __CL_UINT4__)
        //    __cl_uint4     v4[2];
        //#endif
        //#if defined( __CL_UINT8__ )
        //    __cl_uint8     v8;
        //#endif
        //}cl_uint8;

        //typedef union
        //{
        //    uint CL_ALIGNED(64) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ uint x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ uint s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_uint8 lo, hi; };
        //#endif
        //#if defined( __CL_UINT2__)
        //    __cl_uint2     v2[8];
        //#endif
        //#if defined( __CL_UINT4__)
        //    __cl_uint4     v4[4];
        //#endif
        //#if defined( __CL_UINT8__ )
        //    __cl_uint8     v8[2];
        //#endif
        //#if defined( __CL_UINT16__ )
        //    __cl_uint16    v16;
        //#endif
        //}cl_uint16;

        ///* ---- cl_longn ---- */
        //typedef union
        //{
        //    long CL_ALIGNED(16) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ long x, y; };
        //__CL_ANON_STRUCT__ struct{ long s0, s1; };
        //__CL_ANON_STRUCT__ struct{ long lo, hi; };
        //#endif
        //#if defined( __CL_LONG2__)
        //    __cl_long2     v2;
        //#endif
        //}cl_long2;

        //typedef union
        //{
        //    long CL_ALIGNED(32) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ long x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ long s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_long2 lo, hi; };
        //#endif
        //#if defined( __CL_LONG2__)
        //    __cl_long2     v2[2];
        //#endif
        //#if defined( __CL_LONG4__)
        //    __cl_long4     v4;
        //#endif
        //}cl_long4;

        ///* cl_long3 is identical in size, alignment and behavior to cl_long4. See section 6.1.5. */
        //typedef cl_long4  cl_long3;

        //typedef union
        //{
        //    long CL_ALIGNED(64) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ long x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ long s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_long4 lo, hi; };
        //#endif
        //#if defined( __CL_LONG2__)
        //    __cl_long2     v2[4];
        //#endif
        //#if defined( __CL_LONG4__)
        //    __cl_long4     v4[2];
        //#endif
        //#if defined( __CL_LONG8__ )
        //    __cl_long8     v8;
        //#endif
        //}cl_long8;

        //typedef union
        //{
        //    long CL_ALIGNED(128) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ long x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ long s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_long8 lo, hi; };
        //#endif
        //#if defined( __CL_LONG2__)
        //    __cl_long2     v2[8];
        //#endif
        //#if defined( __CL_LONG4__)
        //    __cl_long4     v4[4];
        //#endif
        //#if defined( __CL_LONG8__ )
        //    __cl_long8     v8[2];
        //#endif
        //#if defined( __CL_LONG16__ )
        //    __cl_long16    v16;
        //#endif
        //}cl_long16;


        ///* ---- cl_ulongn ---- */
        //typedef union
        //{
        //    ulong CL_ALIGNED(16) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ulong x, y; };
        //__CL_ANON_STRUCT__ struct{ ulong s0, s1; };
        //__CL_ANON_STRUCT__ struct{ ulong lo, hi; };
        //#endif
        //#if defined( __CL_ULONG2__)
        //    __cl_ulong2     v2;
        //#endif
        //}cl_ulong2;

        //typedef union
        //{
        //    ulong CL_ALIGNED(32) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ulong x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ulong s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_ulong2 lo, hi; };
        //#endif
        //#if defined( __CL_ULONG2__)
        //    __cl_ulong2     v2[2];
        //#endif
        //#if defined( __CL_ULONG4__)
        //    __cl_ulong4     v4;
        //#endif
        //}cl_ulong4;

        ///* cl_ulong3 is identical in size, alignment and behavior to cl_ulong4. See section 6.1.5. */
        //typedef cl_ulong4  cl_ulong3;

        //typedef union
        //{
        //    ulong CL_ALIGNED(64) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ulong x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ ulong s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_ulong4 lo, hi; };
        //#endif
        //#if defined( __CL_ULONG2__)
        //    __cl_ulong2     v2[4];
        //#endif
        //#if defined( __CL_ULONG4__)
        //    __cl_ulong4     v4[2];
        //#endif
        //#if defined( __CL_ULONG8__ )
        //    __cl_ulong8     v8;
        //#endif
        //}cl_ulong8;

        //typedef union
        //{
        //    ulong CL_ALIGNED(128) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ ulong x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ ulong s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_ulong8 lo, hi; };
        //#endif
        //#if defined( __CL_ULONG2__)
        //    __cl_ulong2     v2[8];
        //#endif
        //#if defined( __CL_ULONG4__)
        //    __cl_ulong4     v4[4];
        //#endif
        //#if defined( __CL_ULONG8__ )
        //    __cl_ulong8     v8[2];
        //#endif
        //#if defined( __CL_ULONG16__ )
        //    __cl_ulong16    v16;
        //#endif
        //}cl_ulong16;


        ///* --- cl_floatn ---- */

        //typedef union
        //{
        //    float CL_ALIGNED(8) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ float x, y; };
        //__CL_ANON_STRUCT__ struct{ float s0, s1; };
        //__CL_ANON_STRUCT__ struct{ float lo, hi; };
        //#endif
        //#if defined( __CL_FLOAT2__)
        //    __cl_float2     v2;
        //#endif
        //}cl_float2;

        //typedef union
        //{
        //    float CL_ALIGNED(16) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ float x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ float s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_float2 lo, hi; };
        //#endif
        //#if defined( __CL_FLOAT2__)
        //    __cl_float2     v2[2];
        //#endif
        //#if defined( __CL_FLOAT4__)
        //    __cl_float4     v4;
        //#endif
        //}cl_float4;

        ///* cl_float3 is identical in size, alignment and behavior to cl_float4. See section 6.1.5. */
        //typedef cl_float4  cl_float3;

        //typedef union
        //{
        //    float CL_ALIGNED(32) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ float x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ float s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_float4 lo, hi; };
        //#endif
        //#if defined( __CL_FLOAT2__)
        //    __cl_float2     v2[4];
        //#endif
        //#if defined( __CL_FLOAT4__)
        //    __cl_float4     v4[2];
        //#endif
        //#if defined( __CL_FLOAT8__ )
        //    __cl_float8     v8;
        //#endif
        //}cl_float8;

        //typedef union
        //{
        //    float CL_ALIGNED(64) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ float x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ float s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_float8 lo, hi; };
        //#endif
        //#if defined( __CL_FLOAT2__)
        //    __cl_float2     v2[8];
        //#endif
        //#if defined( __CL_FLOAT4__)
        //    __cl_float4     v4[4];
        //#endif
        //#if defined( __CL_FLOAT8__ )
        //    __cl_float8     v8[2];
        //#endif
        //#if defined( __CL_FLOAT16__ )
        //    __cl_float16    v16;
        //#endif
        //}cl_float16;

        /* --- cl_doublen ---- */

        //typedef union
        //{
        //    double CL_ALIGNED(16) s [2];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ double x, y; };
        //__CL_ANON_STRUCT__ struct{ double s0, s1; };
        //__CL_ANON_STRUCT__ struct{ double lo, hi; };
        //#endif
        //#if defined( __CL_DOUBLE2__)
        //    __cl_double2     v2;
        //#endif
        //}cl_double2;

        //typedef union
        //{
        //    double CL_ALIGNED(32) s [4];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ double x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ double s0, s1, s2, s3; };
        //__CL_ANON_STRUCT__ struct{ cl_double2 lo, hi; };
        //#endif
        //#if defined( __CL_DOUBLE2__)
        //    __cl_double2     v2[2];
        //#endif
        //#if defined( __CL_DOUBLE4__)
        //    __cl_double4     v4;
        //#endif
        //}cl_double4;

        ///* cl_double3 is identical in size, alignment and behavior to cl_double4. See section 6.1.5. */
        //typedef cl_double4  cl_double3;

        //typedef union
        //{
        //    double CL_ALIGNED(64) s [8];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ double x, y, z, w; };
        //__CL_ANON_STRUCT__ struct{ double s0, s1, s2, s3, s4, s5, s6, s7; };
        //__CL_ANON_STRUCT__ struct{ cl_double4 lo, hi; };
        //#endif
        //#if defined( __CL_DOUBLE2__)
        //    __cl_double2     v2[4];
        //#endif
        //#if defined( __CL_DOUBLE4__)
        //    __cl_double4     v4[2];
        //#endif
        //#if defined( __CL_DOUBLE8__ )
        //    __cl_double8     v8;
        //#endif
        //}cl_double8;

        //typedef union
        //{
        //    double CL_ALIGNED(128) s [16];
        //#if __CL_HAS_ANON_STRUCT__
        //    __CL_ANON_STRUCT__ struct{ double x, y, z, w, __spacer4, __spacer5, __spacer6, __spacer7, __spacer8, __spacer9, sa, sb, sc, sd, se, sf; };
        //__CL_ANON_STRUCT__ struct{ double s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, sA, sB, sC, sD, sE, sF; };
        //__CL_ANON_STRUCT__ struct{ cl_double8 lo, hi; };
        //#endif
        //#if defined( __CL_DOUBLE2__)
        //    __cl_double2     v2[8];
        //#endif
        //#if defined( __CL_DOUBLE4__)
        //    __cl_double4     v4[4];
        //#endif
        //#if defined( __CL_DOUBLE8__ )
        //    __cl_double8     v8[2];
        //#endif
        //#if defined( __CL_DOUBLE16__ )
        //    __cl_double16    v16;
        //#endif
        //}cl_double16;



        /******************************************************************************/

        //        typedef struct _cl_platform_id *    CLPlatformPtr;
        //typedef struct _cl_device_id *      CLDevicePtr;
        //typedef struct _cl_context *        CLContextPtr;
        //typedef struct _cl_command_queue *  CLCommandQueuePtr;
        //typedef struct _cl_mem *            CLMemoryPtr;
        //typedef struct _cl_program *        CLProgramPtr;
        //typedef struct _cl_kernel *         CLKernelPtr;
        //typedef struct _cl_event *          CLEventPtr;
        //typedef struct _cl_sampler *        CLSamplerPtr;

        //typedef uint             cl_bool;                     /* WARNING!  Unlike cl_ types in cl_platform.h, cl_bool is not guaranteed to be the same size as the bool in kernels. */
        //typedef ulong cl_bitfield;
        //typedef ulong cl_properties;
        //typedef ulong CLDeviceType;
        //typedef uint CLPlatformInfo;
        //typedef uint             CLDeviceInfo;
        //typedef ulong         CLDeviceFPConfig;
        //typedef uint             CLDeviceMemoryCacheType;
        //typedef uint             CLDeviceLocalMemoryType;
        //typedef ulong         CLDeviceExecCapabilities;
        //#ifdef CL_VERSION_2_0
        //typedef ulong         CLDeviceSVMCapabilities;
        //#endif
        //typedef ulong         CLCommandQueueProperties;
        //#ifdef CL_VERSION_1_2
        //typedef intptr_t            CLDevicePartitionProperty;
        //typedef ulong         CLDeviceAffinityDomain;
        //#endif

        //typedef intptr_t            CLContextProperties;
        //typedef uint             CLContextInfo;
        //#ifdef CL_VERSION_2_0
        //typedef ulong       cl_queue_properties;
        //#endif
        //typedef uint             CLCommandQueueInfo;
        //typedef uint             CLChannelOrder;
        //typedef uint             CLChannelType;
        //typedef ulong         CLMemoryFlags;
        //#ifdef CL_VERSION_2_0
        //typedef ulong         CLSVMMemoryFlags;
        //#endif
        //typedef uint             CLMemoryObjectType;
        //typedef uint             CLMemoryInfo;
        //#ifdef CL_VERSION_1_2
        //typedef ulong         CLMemoryMigrationFlags;
        //#endif
        //typedef uint             CLImageInfo;
        //#ifdef CL_VERSION_1_1
        //typedef uint             CLBufferCreateType;
        //#endif
        //typedef uint             CLAddressingMode;
        //typedef uint             CLFilterMode;
        //typedef uint             CLSamplerInfo;
        //typedef ulong         CLMapFlags;
        //#ifdef CL_VERSION_2_0
        //typedef intptr_t            cl_pipe_properties;
        //typedef uint             CLPipeInfo;
        //#endif
        //typedef uint             CLProgramInfo;
        //typedef uint             CLProgramBuildInfo;
        //#ifdef CL_VERSION_1_2
        //typedef uint             CLProgramBinaryType;
        //#endif
        //typedef int              CLBuildStatus;
        //typedef uint             CLKernelInfo;
        //#ifdef CL_VERSION_1_2
        //typedef uint             CLKernelArgumentInfo;
        //typedef uint             CLKernelArgumentAddressQualifier;
        //typedef uint             CLKernelArgumentAccessQualifier;
        //typedef ulong         CLKernelArgumentTypeQualifier;
        //#endif
        //typedef uint             CLKernelWorkGroupInfo;
        //#ifdef CL_VERSION_2_1
        //typedef uint             cl_kernel_sub_group_info;
        //#endif
        //typedef uint             CLEventInfo;
        //typedef uint             CLCommandType;
        //typedef uint             CLProfilingInfo;
        //#ifdef CL_VERSION_2_0
        //typedef ulong       CLSamplerProperties;
        //typedef uint             CLKernelExecInfo;
        //#endif
        //#ifdef CL_VERSION_3_0
        //typedef ulong         cl_device_atomic_capabilities;
        //typedef ulong         cl_device_device_enqueue_capabilities;
        //typedef uint             cl_khronos_vendor_id;
        //typedef ulong       cl_mem_properties;
        //typedef uint             cl_version;
        //#endif

        /******************************************************************************/

        ///* Error Codes */
        //const int Success                            =      0
        //const int DeviceNotFound                   =      -1
        //const int DeviceNotAvailable               =      -2
        //const int CompilerNotAvailable             =      -3
        //const int MemoryObjectAllocationFailure      =      -4
        //const int OutOfResources                   =      -5
        //const int OutOfHostMemory                 =      -6
        //const int ProfilingInfoNotAvailable       =      -7
        //const int MemoryCopyOverlap                   =      -8
        //const int ImageFormatMismatch              =      -9
        //const int ImageFormatNotSupported         =      -10
        //const int BuildProgramFailure              =      -11
        //const int MapFailure                        =      -12
        //#ifdef CL_VERSION_1_1
        //const int MisalignedSubBufferOffset       =      -13
        //const int ExecStatusErrorForEventsInWaitList= -14
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int CompileProgramFailure            =      -15
        //const int LinkerNotAvailable               =      -16
        //const int LinkProgramFailure               =      -17
        //const int DevicePartitionFailed            =      -18
        //const int KernelArgInfoNotAvailable      =      -19
        //#endif

        //const int InvalidValue                      =      -30
        //const int InvalidDeviceType                =      -31
        //const int InvalidPlatform                   =      -32
        //const int InvalidDevice                     =      -33
        //const int InvalidContext                    =      -34
        //const int InvalidQueueProperties           =      -35
        //const int InvalidCommandQueue              =      -36
        //const int InvalidHostPointer                   =      -37
        //const int InvalidMemoryObject                 =      -38
        //const int InvalidImageFormatDescriptor    =      -39
        //const int InvalidImageSize                 =      -40
        //const int InvalidSampler                    =      -41
        //const int InvalidBinary                     =      -42
        //const int InvalidBuildOptions              =      -43
        //const int InvalidProgram                    =      -44
        //const int InvalidProgramExecutable         =      -45
        //const int InvalidKernelName                =      -46
        //const int InvalidKernelDefinition          =      -47
        //const int InvalidKernel                     =      -48
        //const int InvalidArgumentIndex                  =      -49
        //const int InvalidArgumentValue                  =      -50
        //const int InvalidArgumentSize                   =      -51
        //const int InvalidKernelArguments                =      -52
        //const int InvalidWorkDimension             =      -53
        //const int InvalidWorkGroupSize            =      -54
        //const int InvalidWorkItemSize             =      -55
        //const int InvalidGlobalOffset              =      -56
        //const int InvalidEventWaitList            =      -57
        //const int InvalidEvent                      =      -58
        //const int InvalidOperation                  =      -59
        //const int InvalidGLObject                  =      -60
        //const int InvalidBufferSize                =      -61
        //const int InvalidMipLevel                  =      -62
        //const int InvalidGlobalWorkSize           =      -63
        //#ifdef CL_VERSION_1_1
        //const int InvalidProperty                   =      -64
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int InvalidImageDescriptor           =      -65
        //const int InvalidCompilerOptions           =      -66
        //const int InvalidLinkerOptions             =      -67
        //const int InvalidDevicePartitionCount     =      -68
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int InvalidPipeSize                  =      -69
        //const int InvalidDeviceQueue               =      -70
        //#endif
        //#ifdef CL_VERSION_2_2
        //const int InvalidSpecID                    =      -71
        //const int MaxSizeRestrictionExceeded      =      -72
        //#endif


        ///* cl_bool */
        //const int CL_FALSE                              =      0
        //const int CL_TRUE                               =      1
        //#ifdef CL_VERSION_1_2
        //const int CL_BLOCKING                           =      CL_TRUE
        //const int CL_NON_BLOCKING                       =      CL_FALSE
        //#endif

        ///* uint */
        //const int Profile                   =      0x0900
        //const int Version                   =      0x0901
        //const int Name                      =      0x0902
        //const int Vendor                    =      0x0903
        //const int Extensions                =      0x0904
        //#ifdef CL_VERSION_2_1
        //const int CL_PLATFORM_HOST_TIMER_RESOLUTION     =      0x0905
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_PLATFORM_NUMERIC_VERSION           =      0x0906
        //const int CL_PLATFORM_EXTENSIONS_WITH_VERSION   =      0x0907
        //#endif

        ///* ulong - bitfield */
        //const int Default                =      (1 << 0)
        //const int CPU                    =      (1 << 1)
        //const int GPU                    =      (1 << 2)
        //const int Accelerator            =      (1 << 3)
        //#ifdef CL_VERSION_1_2
        //const int Custom                 =      (1 << 4)
        //#endif
        //const int All                    =      0xFFFFFFFF

        ///* CLDeviceInfo */
        //const int Type                        =           0x1000
        //const int VendorID                   =           0x1001
        //const int MaxComputeUnits           =           0x1002
        //const int MaxWorkItemDimensions    =           0x1003
        //const int MaxWorkGroupSize         =           0x1004
        //const int MaxWorkGroupItemSizes         =           0x1005
        //const int PreferredVectorWidthChar =           0x1006
        //const int PreferredVectorWidthShort=           0x1007
        //const int PreferredVectorWidthInt  =           0x1008
        //const int PreferredVectorWidthLong =           0x1009
        //const int PreferredVectorWidthFloat=           0x100A
        //const int PreferredVectorWidthDouble=          0x100B
        //const int MaxClockFrequency         =           0x100C
        //const int AddressBits                =           0x100D
        //const int MaxReadImageArgs         =           0x100E
        //const int MaxWriteImageArgs        =           0x100F
        //const int MaxMemoryAllocationSize          =           0x1010
        //const int Image2DMaxWidth           =           0x1011
        //const int Image2DMaxHeight          =           0x1012
        //const int Image3DMaxWidth           =           0x1013
        //const int Image3DMaxHeight          =           0x1014
        //const int Image3DMaxDepth           =           0x1015
        //const int ImageSupport               =           0x1016
        //const int MaxParameterSize          =           0x1017
        //const int MaxSamplers                =           0x1018
        //const int MemoryBaseAddressAlignment         =           0x1019
        //const int MinDataTypeAlignmentSize    =           0x101A
        //const int SingleFPConfig            =           0x101B
        //const int GlobalMemoryCacheType       =           0x101C
        //const int GlobalMemoryCachelineSize   =           0x101D
        //const int GlobalMemoryCacheSize       =           0x101E
        //const int GlobalMemorySize             =           0x101F
        //const int MaxConstantBufferSize    =           0x1020
        //const int MaxConstantArguments           =           0x1021
        //const int LocalMemoryType              =           0x1022
        //const int LocalMemorySize              =           0x1023
        //const int ErrorCorrectionSupport    =           0x1024
        //const int ProfilingTimerResolution  =           0x1025
        //const int EndianLittle               =           0x1026
        //const int Available                   =           0x1027
        //const int CompilerAvailable          =           0x1028
        //const int ExecutionCapabilities      =           0x1029
        //const int CL_DEVICE_QUEUE_PROPERTIES            =           0x102A    /* deprecated */
        //#ifdef CL_VERSION_2_0
        //const int QueueOnHostProperties    =           0x102A
        //#endif
        //const int Name                        =           0x102B
        //const int Vendor                      =           0x102C
        //const int DriverVersion                     =           0x102D
        //const int Profile                     =           0x102E
        //const int Version                     =           0x102F
        //const int Extensions                  =           0x1030
        //const int Platform                    =           0x1031
        //#ifdef CL_VERSION_1_2
        //const int DoubleFPConfig            =           0x1032
        //#endif
        ///* 0x1033 reserved for HalfFPConfig which is already defined in "cl_ext.h" */
        //#ifdef CL_VERSION_1_1
        //const int PreferredVectorWidthHalf  =          0x1034
        //const int HostUnifiedMemory          =          0x1035   /* deprecated */
        //const int NativeVectorWidthChar     =          0x1036
        //const int NativeVectorWidthShort    =          0x1037
        //const int NativeVectorWidthInt      =          0x1038
        //const int NativeVectorWidthLong     =          0x1039
        //const int NativeVectorWidthFloat    =          0x103A
        //const int NativeVectorWidthDouble   =          0x103B
        //const int NativeVectorWidthHalf     =          0x103C
        //const int OpenCLVersion             =          0x103D
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int LinkerAvailable             =          0x103E
        //const int BuiltInKernels             =          0x103F
        //const int ImageMaxBufferSize        =          0x1040
        //const int ImageMaxArraySize         =          0x1041
        //const int ParentDevice                =          0x1042
        //const int PartitionMaxSubDevices    =          0x1043
        //const int PartitionProperties         =          0x1044
        //const int PartitionAffinityDomain    =          0x1045
        //const int PartitionType               =          0x1046
        //const int ReferenceCount              =          0x1047
        //const int PreferredInteropUserSync  =          0x1048
        //const int PrintfBufferSize           =          0x1049
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int ImagePitchAlignment         =         0x104A
        //const int ImageBaseAddressAlignment  =         0x104B
        //const int MaxReadWriteImageArgs     =         0x104C
        //const int MaxGlobalVariableSize      =         0x104D
        //const int QueueOnDeviceProperties    =         0x104E
        //const int QueueOnDevicePreferredSize=         0x104F
        //const int QueueOnDeviceMaxSize      =         0x1050
        //const int MaxOnDeviceQueues          =         0x1051
        //const int MaxOnDeviceEvents          =         0x1052
        //const int SVMCapabilities              =         0x1053
        //const int GlobablVariablePreferredTotalSize=   0x1054
        //const int MaxPipeArguments                 =         0x1055
        //const int MaxActiveReservations  =         0x1056
        //const int PipeMaxPacketSize          =         0x1057
        //const int PreferredPlatformAtomicAlignment =   0x1058
        //const int PreferredGlobalAtomicAlignment   =   0x1059
        //const int PreferredLocalAtomicAlignment    =   0x105A
        //#endif
        //#ifdef CL_VERSION_2_1
        //const int CL_DEVICE_IL_VERSION                          =   0x105B
        //const int CL_DEVICE_MAX_NUM_SUB_GROUPS                   =  0x105C
        //const int CL_DEVICE_SUB_GROUP_INDEPENDENT_FORWARD_PROGRESS= 0x105D
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_DEVICE_NUMERIC_VERSION                      =  0x105E
        //const int CL_DEVICE_EXTENSIONS_WITH_VERSION              =  0x1060
        //const int CL_DEVICE_ILS_WITH_VERSION                     =  0x1061
        //const int CL_DEVICE_BUILT_IN_KERNELS_WITH_VERSION        =  0x1062
        //const int CL_DEVICE_ATOMIC_MEMORY_CAPABILITIES           =  0x1063
        //const int CL_DEVICE_ATOMIC_FENCE_CAPABILITIES            =  0x1064
        //const int CL_DEVICE_NON_UNIFORM_WORK_GROUP_SUPPORT       =  0x1065
        //const int CL_DEVICE_OPENCL_C_ALL_VERSIONS                =  0x1066
        //const int CL_DEVICE_PREFERRED_WORK_GROUP_SIZE_MULTIPLE   =  0x1067
        //const int CL_DEVICE_WORK_GROUP_COLLECTIVE_FUNCTIONS_SUPPORT= 0x1068
        //const int CL_DEVICE_GENERIC_ADDRESS_SPACE_SUPPORT        =  0x1069
        ///* 0x106A to 0x106E - Reserved for upcoming KHR extension */
        //const int CL_DEVICE_OPENCL_C_FEATURES                    =  0x106F
        //const int CL_DEVICE_DEVICE_ENQUEUE_CAPABILITIES          =  0x1070
        //const int CL_DEVICE_PIPE_SUPPORT                         =  0x1071
        //const int CL_DEVICE_LATEST_CONFORMANCE_VERSION_PASSED    =  0x1072
        //#endif

        ///* CLDeviceFPConfig - bitfield */
        //const int Denorm                             =   (1 << 0)
        //const int InfinityAndNaNs                            =   (1 << 1)
        //const int RoundToNearest                   =   (1 << 2)
        //const int RoundToZero                      =   (1 << 3)
        //const int RoundToInfinity                       =   (1 << 4)
        //const int FusedMultiplyAdd                                =   (1 << 5)
        //#ifdef CL_VERSION_1_1
        //const int SoftwareFloats                          =  (1 << 6)
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int CorrectlyRoundedDivideAndSqrt       =  (1 << 7)
        //#endif

        ///* CLDeviceMemoryCacheType */
        //const int None                                   =  0x0
        //const int ReadOnlyCache                        =  0x1
        //const int ReadWriteCache                       =  0x2

        ///* CLDeviceLocalMemoryType */
        //const int Local                                  =  0x1
        //const int Global                                 =  0x2

        ///* CLDeviceExecCapabilities - bitfield */
        //const int Kernel                            =  (1 << 0)
        //const int NativeKernel                     =  (1 << 1)

        ///* CLCommandQueueProperties - bitfield */
        //const int OutOfOrderExecModeEnable    =  (1 << 0)
        //const int ProfilingEnable                 =  (1 << 1)
        //#ifdef CL_VERSION_2_0
        //const int CL_QUEUE_ON_DEVICE                         = (1 << 2)
        //const int CL_QUEUE_ON_DEVICE_DEFAULT                 = (1 << 3)
        //#endif

        ///* CLContextInfo */
        //const int ReferenceCount               =   0x1080
        //const int Devices                       =   0x1081
        //const int Properties                    =   0x1082
        //#ifdef CL_VERSION_1_1
        //const int NumberOfDevices                   =   0x1083
        //#endif

        ///* CLContextProperties */
        //const int Platform                      =   0x1084
        //#ifdef CL_VERSION_1_2
        //const int InteropUserSync              =  0x1085
        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLDevicePartitionProperty */
        //const int Equally             =    0x1086
        //const int ByCounts           =    0x1087
        //const int ByCountsListEnd  =    0x0
        //const int ByAffinityDomain  =    0x1088

        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLDeviceAffinityDomain */
        //const int Numa             =  (1 << 0)
        //const int L4Cache         =  (1 << 1)
        //const int L3Cache         =  (1 << 2)
        //const int L2Cache         =  (1 << 3)
        //const int L1Cache         =  (1 << 4)
        //const int NextPartitionable= (1 << 5)

        //#endif

        //#ifdef CL_VERSION_2_0

        ///* CLDeviceSVMCapabilities */
        //const int CourseGrainBuffer        =   (1 << 0)
        //const int FineGrainBuffer          =   (1 << 1)
        //const int FineGrainSystem          =   (1 << 2)
        //const int Atomics                    =   (1 << 3)

        //#endif

        ///* CLCommandQueueInfo */
        //const int Context                         =   0x1090
        //const int Device                          =   0x1091
        //const int ReferenceCount                 =   0x1092
        //const int Properties                      =   0x1093
        //#ifdef CL_VERSION_2_0
        //const int Size                            =   0x1094
        //#endif
        //#ifdef CL_VERSION_2_1
        //const int CL_QUEUE_DEVICE_DEFAULT                  =   0x1095
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_QUEUE_PROPERTIES_ARRAY                =   0x1098
        //#endif

        ///* CLMemoryFlags and CLSVMMemoryFlags - bitfield */
        //const int ReadWrite                       =    (1 << 0)
        //const int WriteOnly                       =    (1 << 1)
        //const int ReadOnly                        =    (1 << 2)
        //const int UseHostPointer                     =    (1 << 3)
        //const int AllocateHostPointer                   =    (1 << 4)
        //const int CopyHostPointer                    =    (1 << 5)
        ///* reserved                                         (1 << 6)    */
        //#ifdef CL_VERSION_1_2
        //const int HostWriteOnly                  =    (1 << 7)
        //const int HostReadOnly                   =    (1 << 8)
        //const int HostNoAccess                   =    (1 << 9)
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int FineGrainBuffer            =    (1 << 10)   /* used by CLSVMMemoryFlags only */
        //const int Atomics                      =    (1 << 11)   /* used by CLSVMMemoryFlags only */
        //const int CL_MEM_KERNEL_READ_AND_WRITE            =    (1 << 12)
        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLMemoryMigrationFlags - bitfield */
        //const int Host               =   (1 << 0)
        //const int ContentUndefined  =   (1 << 1)

        //#endif

        ///* CLChannelOrder */
        //const int R                                        0x10B0
        //const int A                                        0x10B1
        //const int RG                                       0x10B2
        //const int RA                                       0x10B3
        //const int RGB                                      0x10B4
        //const int RGBA                                     0x10B5
        //const int BGRA                                     0x10B6
        //const int ARGB                                     0x10B7
        //const int Intensity                                0x10B8
        //const int Luminance                                0x10B9
        //#ifdef CL_VERSION_1_1
        //const int Rx                                       0x10BA
        //const int RGx                                      0x10BB
        //const int RGBx                                     0x10BC
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int Depth                                    0x10BD
        //const int DepthStencil                            0x10BE
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int sRGB                                     0x10BF
        //const int sRGBx                                    0x10C0
        //const int sRGBA                                    0x10C1
        //const int sBGRA                                    0x10C2
        //const int ABGR                                     0x10C3
        //#endif

        ///* CLChannelType */
        //const int SignedNormalizedInt8                               0x10D0
        //const int SignedNormalizedInt16                              0x10D1
        //const int UnsignedNormalizedInt8                               0x10D2
        //const int UnsignedNormalizedInt16                              0x10D3
        //const int UnsignedNormalizedShort565                          0x10D4
        //const int UnsignedNormalizedShort555                          0x10D5
        //const int UnsignedNormalizedInt101010                         0x10D6
        //const int SignedInt8                              0x10D7
        //const int SignedInt16                             0x10D8
        //const int SignedInt32                             0x10D9
        //const int UnsignedInt8                            0x10DA
        //const int UnsignedInt16                           0x10DB
        //const int UnsignedInt32                           0x10DC
        //const int HalfFloat                               0x10DD
        //const int Float                                    0x10DE
        //#ifdef CL_VERSION_1_2
        //const int UnsignedNormalizedInt24                              0x10DF
        //#endif
        //#ifdef CL_VERSION_2_1
        //const int CL_UNORM_INT_101010_2                       0x10E0
        //#endif

        ///* CLMemoryObjectType */
        //const int Buffer                        0x10F0
        //const int Image2D                       0x10F1
        //const int Image3D                       0x10F2
        //#ifdef CL_VERSION_1_2
        //const int Image2DArray                 0x10F3
        //const int Image1D                       0x10F4
        //const int Image1DArray                 0x10F5
        //const int Image1DBuffer                0x10F6
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int Pipe                          0x10F7
        //#endif

        ///* CLMemoryInfo */
        //const int Type                                 0x1100
        //const int Flags                                0x1101
        //const int Size                                 0x1102
        //const int HostPointer                             0x1103
        //const int MapCount                            0x1104
        //const int ReferenceCount                      0x1105
        //const int Context                              0x1106
        //#ifdef CL_VERSION_1_1
        //const int AssociatedMemoryObject                 0x1107
        //const int Offset                               0x1108
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int UsesSVMPointer                     0x1109
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_MEM_PROPERTIES                           0x110A
        //#endif

        ///* CLImageInfo */
        //const int Format                             0x1110
        //const int ElementSize                       0x1111
        //const int RowPitch                          0x1112
        //const int SlicePitch                        0x1113
        //const int Width                              0x1114
        //const int Height                             0x1115
        //const int Depth                              0x1116
        //#ifdef CL_VERSION_1_2
        //const int ArraySize                         0x1117
        //const int Buffer                             0x1118
        //const int NumberOfMipLevels                     0x1119
        //const int NumberOfSamples                        0x111A
        //#endif


        ///* CLPipeInfo */
        //#ifdef CL_VERSION_2_0
        //const int PacketSize                         0x1120
        //const int MaxPackets                         0x1121
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_PIPE_PROPERTIES                          0x1122
        //#endif

        ///* CLAddressingMode */
        //const int None                             0x1130
        //const int ClampToEdge                    0x1131
        //const int Clamp                            0x1132
        //const int Repeat                           0x1133
        //#ifdef CL_VERSION_1_1
        //const int MirroredRepeat                  0x1134
        //#endif

        ///* CLFilterMode */
        //const int Nearest                           0x1140
        //const int Linear                            0x1141

        ///* CLSamplerInfo */
        //const int ReferenceCount                  0x1150
        //const int Context                          0x1151
        //const int NormalizedCoords                0x1152
        //const int AddressingModes                  0x1153
        //const int FilterMode                      0x1154
        //#ifdef CL_VERSION_2_0
        ///* These enumerants are for the cl_khr_mipmap_image extension.
        //   They have since been added to cl_ext.h with an appropriate
        //   KHR suffix, but are left here for backwards compatibility. */
        //const int CL_SAMPLER_MIP_FILTER_MODE                  0x1155
        //const int CL_SAMPLER_LOD_MIN                          0x1156
        //const int CL_SAMPLER_LOD_MAX                          0x1157
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_SAMPLER_PROPERTIES                       0x1158
        //#endif

        ///* CLMapFlags - bitfield */
        //const int Read                                 (1 << 0)
        //const int Write                                (1 << 1)
        //#ifdef CL_VERSION_1_2
        //const int WriteInvalidateRegion              (1 << 2)
        //#endif

        ///* CLProgramInfo */
        //const int ReferenceCount                  0x1160
        //const int Context                          0x1161
        //const int NumberOfDevices                      0x1162
        //const int Devices                          0x1163
        //const int Source                           0x1164
        //const int BinarySizes                     0x1165
        //const int Binaries                         0x1166
        //#ifdef CL_VERSION_1_2
        //const int NumberOfKernels                      0x1167
        //const int KernelNames                     0x1168
        //#endif
        //#ifdef CL_VERSION_2_1
        //const int CL_PROGRAM_IL                               0x1169
        //#endif
        //#ifdef CL_VERSION_2_2
        //const int CL_PROGRAM_SCOPE_GLOBAL_CTORS_PRESENT       0x116A
        //const int CL_PROGRAM_SCOPE_GLOBAL_DTORS_PRESENT       0x116B
        //#endif

        ///* CLProgramBuildInfo */
        //const int Status                     0x1181
        //const int Options                    0x1182
        //const int Log                        0x1183
        //#ifdef CL_VERSION_1_2
        //const int BinaryType                      0x1184
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int GlobablVariableTotalSize 0x1185
        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLProgramBinaryType */
        //const int None                 0x0
        //const int CompiledObject      0x1
        //const int Library              0x2
        //const int Executable           0x4

        //#endif

        ///* CLBuildStatus */
        //const int Success                            0
        //const int None                               -1
        //const int Error                              -2
        //const int InProgress                        -3

        ///* CLKernelInfo */
        //const int FunctionName                     0x1190
        //const int NumberOfArguments                          0x1191
        //const int ReferenceCount                   0x1192
        //const int Context                           0x1193
        //const int Program                           0x1194
        //#ifdef CL_VERSION_1_2
        //const int Attributes                        0x1195
        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLKernelArgumentInfo */
        //const int AddressQualifier             0x1196
        //const int AccessQualifier              0x1197
        //const int TypeName                     0x1198
        //const int TypeQualifier                0x1199
        //const int Name                          0x119A

        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLKernelArgumentAddressQualifier */
        //const int Global                0x119B
        //const int Local                 0x119C
        //const int Constant              0x119D
        //const int Private               0x119E

        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLKernelArgumentAccessQualifier */
        //const int ReadOnly              0x11A0
        //const int WriteOnly             0x11A1
        //const int ReadWrite             0x11A2
        //const int None                   0x11A3

        //#endif

        //#ifdef CL_VERSION_1_2

        ///* CLKernelArgumentTypeQualifier */
        //const int None                     0
        //const int Const                    (1 << 0)
        //const int Restrict                 (1 << 1)
        //const int Volatile                 (1 << 2)
        //#ifdef CL_VERSION_2_0
        //const int Pipe                     (1 << 3)
        //#endif

        //#endif

        ///* CLKernelWorkGroupInfo */
        //const int WorkGroupSize                   0x11B0
        //const int CompileWorkGroupSize           0x11B1
        //const int LocalMemorySize                    0x11B2
        //const int PreferredWorkGroupSizeMultiple 0x11B3
        //const int PrivateMemorySize                  0x11B4
        //#ifdef CL_VERSION_1_2
        //const int GlobalWorkSize                  0x11B5
        //#endif

        //#ifdef CL_VERSION_2_1

        ///* cl_kernel_sub_group_info */
        //const int CL_KERNEL_MAX_SUB_GROUP_SIZE_FOR_NDRANGE    0x2033
        //const int CL_KERNEL_SUB_GROUP_COUNT_FOR_NDRANGE       0x2034
        //const int CL_KERNEL_LOCAL_SIZE_FOR_SUB_GROUP_COUNT    0x11B8
        //const int CL_KERNEL_MAX_NUM_SUB_GROUPS                0x11B9
        //const int CL_KERNEL_COMPILE_NUM_SUB_GROUPS            0x11BA

        //#endif

        //#ifdef CL_VERSION_2_0

        ///* CLKernelExecInfo */
        //const int SVMPointers                0x11B6
        //const int SVMFineGrainSystem   0x11B7

        //#endif

        ///* CLEventInfo */
        //const int CommandQueue                      0x11D0
        //const int CommandType                       0x11D1
        //const int ReferenceCount                    0x11D2
        //const int ExecutionStatus           0x11D3
        //#ifdef CL_VERSION_1_1
        //const int Context                            0x11D4
        //#endif

        ///* CLCommandType */
        //const int NDRangeKernel                   0x11F0
        //const int CL_COMMAND_TASK                             0x11F1
        //const int NativeKernel                    0x11F2
        //const int ReadBuffer                      0x11F3
        //const int WriteBuffer                     0x11F4
        //const int CopyBuffer                      0x11F5
        //const int ReadImage                       0x11F6
        //const int WriteImage                      0x11F7
        //const int CopyImage                       0x11F8
        //const int CopyImageToBuffer             0x11F9
        //const int CopyBufferToImage             0x11FA
        //const int MapBuffer                       0x11FB
        //const int MapImage                        0x11FC
        //const int UnmapMemoryObject                 0x11FD
        //const int Marker                           0x11FE
        //const int AquireGLObjects               0x11FF
        //const int ReleaseGLObjects               0x1200
        //#ifdef CL_VERSION_1_1
        //const int ReadBufferRectangle                 0x1201
        //const int WriteBufferRectangle                0x1202
        //const int CopyBufferRectangle                 0x1203
        //const int User                             0x1204
        //#endif
        //#ifdef CL_VERSION_1_2
        //const int Barrier                          0x1205
        //const int MigrateMemoryObjects              0x1206
        //const int FillBuffer                      0x1207
        //const int FillImage                       0x1208
        //#endif
        //#ifdef CL_VERSION_2_0
        //const int SVMFree                         0x1209
        //const int SVMMemoryCopy                       0x120A
        //const int SVMMemoryFill                      0x120B
        //const int SVMMap                          0x120C
        //const int SVMUnmap                        0x120D
        //#endif
        //#ifdef CL_VERSION_3_0
        //const int CL_COMMAND_SVM_MIGRATE_MEM                  0x120E
        //#endif

        ///* command execution status */
        //const int CL_COMPLETE                                 0x0
        //const int CL_RUNNING                                  0x1
        //const int CL_SUBMITTED                                0x2
        //const int CL_QUEUED                                   0x3

        ///* CLBufferCreateType */
        //#ifdef CL_VERSION_1_1
        //const int Region                0x1220
        //#endif

        ///* CLProfilingInfo */
        //const int Queued                 0x1280
        //const int Submit                 0x1281
        //const int Start                  0x1282
        //const int End                    0x1283
        //#ifdef CL_VERSION_2_0
        //const int Complete               0x1284
        //#endif

        ///* cl_device_atomic_capabilities - bitfield */
        //#ifdef CL_VERSION_3_0
        //const int CL_DEVICE_ATOMIC_ORDER_RELAXED          (1 << 0)
        //const int CL_DEVICE_ATOMIC_ORDER_ACQ_REL          (1 << 1)
        //const int CL_DEVICE_ATOMIC_ORDER_SEQ_CST          (1 << 2)
        //const int CL_DEVICE_ATOMIC_SCOPE_WORK_ITEM        (1 << 3)
        //const int CL_DEVICE_ATOMIC_SCOPE_WORK_GROUP       (1 << 4)
        //const int CL_DEVICE_ATOMIC_SCOPE_DEVICE           (1 << 5)
        //const int CL_DEVICE_ATOMIC_SCOPE_ALL_DEVICES      (1 << 6)
        //#endif

        ///* cl_device_device_enqueue_capabilities - bitfield */
        //#ifdef CL_VERSION_3_0
        //const int CL_DEVICE_QUEUE_SUPPORTED               (1 << 0)
        //const int CL_DEVICE_QUEUE_REPLACEABLE_DEFAULT     (1 << 1)
        //#endif

        ///* cl_khronos_vendor_id */
        //const int CL_KHRONOS_VENDOR_ID_CODEPLAY               0x10004

        //#ifdef CL_VERSION_3_0

        ///* cl_version */
        //const int CL_VERSION_MAJOR_BITS (10)
        //const int CL_VERSION_MINOR_BITS (10)
        //const int CL_VERSION_PATCH_BITS (12)

        //const int CL_VERSION_MAJOR_MASK ((1 << CL_VERSION_MAJOR_BITS) - 1)
        //const int CL_VERSION_MINOR_MASK ((1 << CL_VERSION_MINOR_BITS) - 1)
        //const int CL_VERSION_PATCH_MASK ((1 << CL_VERSION_PATCH_BITS) - 1)

        //const int CL_VERSION_MAJOR(version) \
        //  ((version) >> (CL_VERSION_MINOR_BITS + CL_VERSION_PATCH_BITS))

        //const int CL_VERSION_MINOR(version) \
        //  (((version) >> CL_VERSION_PATCH_BITS) & CL_VERSION_MINOR_MASK)

        //const int CL_VERSION_PATCH(version) ((version) & CL_VERSION_PATCH_MASK)

        //const int CL_MAKE_VERSION(major, minor, patch)                      \
        //  ((((major) & CL_VERSION_MAJOR_MASK)                             \
        //       << (CL_VERSION_MINOR_BITS + CL_VERSION_PATCH_BITS)) |      \
        //   (((minor) & CL_VERSION_MINOR_MASK) << CL_VERSION_PATCH_BITS) | \
        //   ((patch) & CL_VERSION_PATCH_MASK))

        //#endif








        /***************************************************************
* cl_khr_command_buffer
***************************************************************/



        //        const int cl_khr_command_buffer 1
        //const int CL_KHR_COMMAND_BUFFER_EXTENSION_NAME \
        //    "cl_khr_command_buffer"

        ///* CLDeviceInfo */
        //const int CL_DEVICE_COMMAND_BUFFER_CAPABILITIES_KHR           0x12A9
        //const int CL_DEVICE_COMMAND_BUFFER_REQUIRED_QUEUE_PROPERTIES_KHR 0x12AA

        ///* cl_device_command_buffer_capabilities_khr - bitfield */
        //const int CL_COMMAND_BUFFER_CAPABILITY_KERNEL_PRINTF_KHR      (1 << 0)
        //const int CL_COMMAND_BUFFER_CAPABILITY_DEVICE_SIDE_ENQUEUE_KHR (1 << 1)
        //const int CL_COMMAND_BUFFER_CAPABILITY_SIMULTANEOUS_USE_KHR   (1 << 2)
        //const int CL_COMMAND_BUFFER_CAPABILITY_OUT_OF_ORDER_KHR       (1 << 3)

        ///* cl_command_buffer_properties_khr */
        //const int CL_COMMAND_BUFFER_FLAGS_KHR                         0x1293

        ///* cl_command_buffer_flags_khr */
        //const int CL_COMMAND_BUFFER_SIMULTANEOUS_USE_KHR              (1 << 0)

        ///* Error codes */
        //const int CL_INVALID_COMMAND_BUFFER_KHR                       -1138
        //const int CL_INVALID_SYNC_POINT_WAIT_LIST_KHR                 -1139
        //const int CL_INCOMPATIBLE_COMMAND_QUEUE_KHR                   -1140

        ///* cl_command_buffer_info_khr */
        //const int CL_COMMAND_BUFFER_QUEUES_KHR                        0x1294
        //const int CL_COMMAND_BUFFER_NUM_QUEUES_KHR                    0x1295
        //const int CL_COMMAND_BUFFER_REFERENCE_COUNT_KHR               0x1296
        //const int CL_COMMAND_BUFFER_STATE_KHR                         0x1297
        //const int CL_COMMAND_BUFFER_PROPERTIES_ARRAY_KHR              0x1298

        ///* cl_command_buffer_state_khr */
        //const int CL_COMMAND_BUFFER_STATE_RECORDING_KHR               0
        //const int CL_COMMAND_BUFFER_STATE_EXECUTABLE_KHR              1
        //const int CL_COMMAND_BUFFER_STATE_PENDING_KHR                 2
        //const int CL_COMMAND_BUFFER_STATE_INVALID_KHR                 3

        ///* CLCommandType */
        //const int CL_COMMAND_COMMAND_BUFFER_KHR                       0x12A8



        //        /* cl_khr_fp64 extension - no extension const int since it has no functions  */
        //        /* DoubleFPConfig is defined in CL.h for OpenCL >= 120 */

        //#if CL_TARGET_OPENCL_VERSION <= 110
        //const int DoubleFPConfig                       0x1032
        //#endif

        //        /* cl_khr_fp16 extension - no extension const int since it has no functions  */
        //        const int HalfFPConfig                    0x1033

        //const int cl_APPLE_SetMemObjectDestructor 1


        //const int cl_APPLE_ContextLoggingFunctions 1

        /************************
* cl_khr_icd extension *
************************/
        //        const int cl_khr_icd 1

        ///* uint                                                        */
        //const int ICDSuffixKHR                  0x0920

        ///* Additional Error Codes                                                  */
        //const int CL_PLATFORM_NOT_FOUND_KHR                   -1001
        /*******************************
         * cl_khr_il_program extension *
         *******************************/
        //        const int cl_khr_il_program 1

        ///* New property to GetDeviceInfo for retrieving supported intermediate
        // * languages
        // */
        //const int CL_DEVICE_IL_VERSION_KHR                    0x105B

        ///* New property to GetProgramInfo for retrieving for retrieving the IL of a
        // * program
        // */
        //const int CL_PROGRAM_IL_KHR                           0x1169


        //        const int CL_DEVICE_IMAGE_PITCH_ALIGNMENT_KHR              0x104A
        //const int CL_DEVICE_IMAGE_BASE_ADDRESS_ALIGNMENT_KHR       0x104B


        ///**************************************
        // * cl_khr_initialize_memory extension *
        // **************************************/

        //const int MemoryInitializeKHR            0x2030


        ///**************************************
        // * cl_khr_terminate_context extension *
        // **************************************/

        //const int CL_CONTEXT_TERMINATED_KHR                   -1121

        //const int TerminateCapabilityKHR          0x2031
        //const int TerminateKHR                    0x2032

        //const int cl_khr_terminate_context 1


        /*
         * Extension: cl_khr_spir
         *
         * This extension adds support to create an OpenCL program object from a
         * Standard Portable Intermediate Representation (SPIR) instance
         */

        //        const int SPIRVersions                     0x40E0
        //const int Intermediate         0x40E1

        /*****************************************
         * cl_khr_create_command_queue extension *
         *****************************************/
        //const int cl_khr_create_command_queue 1



        /******************************************
        * cl_nv_device_attribute_query extension *
        ******************************************/

        //        /* cl_nv_device_attribute_query extension - no extension const int since it has no functions */
        //        const int CL_DEVICE_COMPUTE_CAPABILITY_MAJOR_NV       0x4000
        //const int CL_DEVICE_COMPUTE_CAPABILITY_MINOR_NV       0x4001
        //const int CL_DEVICE_REGISTERS_PER_BLOCK_NV            0x4002
        //const int CL_DEVICE_WARP_SIZE_NV                      0x4003
        //const int CL_DEVICE_GPU_OVERLAP_NV                    0x4004
        //const int CL_DEVICE_KERNEL_EXEC_TIMEOUT_NV            0x4005
        //const int CL_DEVICE_INTEGRATED_MEMORY_NV              0x4006


        ///*********************************
        //* cl_amd_device_attribute_query *
        //*********************************/

        //const int CL_DEVICE_PROFILING_TIMER_OFFSET_AMD            0x4036
        //const int CL_DEVICE_TOPOLOGY_AMD                          0x4037
        //const int CL_DEVICE_BOARD_NAME_AMD                        0x4038
        //const int CL_DEVICE_GLOBAL_FREE_MEMORY_AMD                0x4039
        //const int CL_DEVICE_SIMD_PER_COMPUTE_UNIT_AMD             0x4040
        //const int CL_DEVICE_SIMD_WIDTH_AMD                        0x4041
        //const int CL_DEVICE_SIMD_INSTRUCTION_WIDTH_AMD            0x4042
        //const int CL_DEVICE_WAVEFRONT_WIDTH_AMD                   0x4043
        //const int CL_DEVICE_GLOBAL_MEM_CHANNELS_AMD               0x4044
        //const int CL_DEVICE_GLOBAL_MEM_CHANNEL_BANKS_AMD          0x4045
        //const int CL_DEVICE_GLOBAL_MEM_CHANNEL_BANK_WIDTH_AMD     0x4046
        //const int CL_DEVICE_LOCAL_MEM_SIZE_PER_COMPUTE_UNIT_AMD   0x4047
        //const int CL_DEVICE_LOCAL_MEM_BANKS_AMD                   0x4048
        //const int CL_DEVICE_THREAD_TRACE_SUPPORTED_AMD            0x4049
        //const int CL_DEVICE_GFXIP_MAJOR_AMD                       0x404A
        //const int CL_DEVICE_GFXIP_MINOR_AMD                       0x404B
        //const int CL_DEVICE_AVAILABLE_ASYNC_QUEUES_AMD            0x404C
        //const int CL_DEVICE_PREFERRED_WORK_GROUP_SIZE_AMD         0x4030
        //const int CL_DEVICE_MAX_WORK_GROUP_SIZE_AMD               0x4031
        //const int CL_DEVICE_PREFERRED_CONSTANT_BUFFER_SIZE_AMD    0x4033
        //const int CL_DEVICE_PCIE_ID_AMD                           0x4034


        ///*********************************
        //* cl_arm_printf extension
        //*********************************/

        //const int CL_PRINTF_CALLBACK_ARM                      0x40B0
        //const int CL_PRINTF_BUFFERSIZE_ARM                    0x40B1


        ///***********************************
        //* cl_ext_device_fission extension
        //***********************************/
        //const int cl_ext_device_fission   1



        //        /* cl_device_partition_property_ext */
        //        const int CL_DEVICE_PARTITION_EQUALLY_EXT             0x4050
        //const int CL_DEVICE_PARTITION_BY_COUNTS_EXT           0x4051
        //const int CL_DEVICE_PARTITION_BY_NAMES_EXT            0x4052
        //const int CL_DEVICE_PARTITION_BY_AFFINITY_DOMAIN_EXT  0x4053

        ///* clDeviceGetInfo selectors */
        //const int CL_DEVICE_PARENT_DEVICE_EXT                 0x4054
        //const int CL_DEVICE_PARTITION_TYPES_EXT               0x4055
        //const int CL_DEVICE_AFFINITY_DOMAINS_EXT              0x4056
        //const int CL_DEVICE_REFERENCE_COUNT_EXT               0x4057
        //const int CL_DEVICE_PARTITION_STYLE_EXT               0x4058

        ///* error codes */
        //const int CL_DEVICE_PARTITION_FAILED_EXT              -1057
        //const int CL_INVALID_PARTITION_COUNT_EXT              -1058
        //const int CL_INVALID_PARTITION_NAME_EXT               -1059

        ///* CL_AFFINITY_DOMAINs */
        //const int CL_AFFINITY_DOMAIN_L1_CACHE_EXT             0x1
        //const int CL_AFFINITY_DOMAIN_L2_CACHE_EXT             0x2
        //const int CL_AFFINITY_DOMAIN_L3_CACHE_EXT             0x3
        //const int CL_AFFINITY_DOMAIN_L4_CACHE_EXT             0x4
        //const int CL_AFFINITY_DOMAIN_NUMA_EXT                 0x10
        //const int CL_AFFINITY_DOMAIN_NEXT_FISSIONABLE_EXT     0x100

        ///* cl_device_partition_property_ext list terminators */
        //const int CL_PROPERTIES_LIST_END_EXT                  ((cl_device_partition_property_ext)0)
        //const int CL_PARTITION_BY_COUNTS_LIST_END_EXT         ((cl_device_partition_property_ext)0)
        //const int CL_PARTITION_BY_NAMES_LIST_END_EXT          ((cl_device_partition_property_ext)0 - 1)


        /***********************************
         * cl_ext_migrate_memobject extension definitions
         ***********************************/
        //        const int cl_ext_migrate_memobject 1

        //typedef ulong cl_mem_migration_flags_ext;

        //        const int CL_MIGRATE_MEM_OBJECT_HOST_EXT              0x1

        //const int CL_COMMAND_MIGRATE_MEM_OBJECT_EXT           0x4040

        /*********************************
        * cl_ext_cxx_for_opencl extension
        *********************************/
        //        const int cl_ext_cxx_for_opencl 1

        //const int CL_DEVICE_CXX_FOR_OPENCL_NUMERIC_VERSION_EXT 0x4230

        ///*********************************
        //* cl_qcom_ext_host_ptr extension
        //*********************************/
        //const int cl_qcom_ext_host_ptr 1

        //const int CL_MEM_EXT_HOST_PTR_QCOM                  (1 << 29)

        //const int CL_DEVICE_EXT_MEM_PADDING_IN_BYTES_QCOM   0x40A0
        //const int CL_DEVICE_PAGE_SIZE_QCOM                  0x40A1
        //const int CL_IMAGE_ROW_ALIGNMENT_QCOM               0x40A2
        //const int CL_IMAGE_SLICE_ALIGNMENT_QCOM             0x40A3
        //const int CL_MEM_HOST_UNCACHED_QCOM                 0x40A4
        //const int CL_MEM_HOST_WRITEBACK_QCOM                0x40A5
        //const int CL_MEM_HOST_WRITETHROUGH_QCOM             0x40A6
        //const int CL_MEM_HOST_WRITE_COMBINING_QCOM          0x40A7


        /*******************************************
        * cl_qcom_ext_host_ptr_iocoherent extension
        ********************************************/

        /* Cache policy specifying io-coherence */
        //const int CL_MEM_HOST_IOCOHERENT_QCOM               0x40A9


        /*********************************
        * cl_qcom_ion_host_ptr extension
        *********************************/

        //const int CL_MEM_ION_HOST_PTR_QCOM                  0x40A8


        /*********************************
        * cl_qcom_android_native_buffer_host_ptr extension
        *********************************/

        //        const int CL_MEM_ANDROID_NATIVE_BUFFER_HOST_PTR_QCOM                  0x40C6


        ///******************************************
        // * cl_img_yuv_image extension *
        // ******************************************/

        //        /* Image formats used in CreateImage */
        //const int CL_NV21_IMG                                 0x40D0
        //const int CL_YV12_IMG                                 0x40D1


        ///******************************************
        // * cl_img_cached_allocations extension *
        // ******************************************/

        //        /* Flag values used by Create */
        //const int CL_MEM_USE_UNCACHED_CPU_MEMORY_IMG          (1 << 26)
        //const int CL_MEM_USE_CACHED_CPU_MEMORY_IMG            (1 << 27)


        ///******************************************
        // * cl_img_use_gralloc_ptr extension *
        // ******************************************/
        //const int cl_img_use_gralloc_ptr 1

        ///* Flag values used by Create */
        //const int CL_MEM_USE_GRALLOC_PTR_IMG                  (1 << 28)

        ///* To be used by clGetEventInfo: */
        //const int CL_COMMAND_ACQUIRE_GRALLOC_OBJECTS_IMG      0x40D2
        //const int CL_COMMAND_RELEASE_GRALLOC_OBJECTS_IMG      0x40D3

        ///* Error codes from clEnqueueAcquireGrallocObjectsIMG and clEnqueueReleaseGrallocObjectsIMG */
        //const int CL_GRALLOC_RESOURCE_NOT_ACQUIRED_IMG        0x40D4
        //const int CL_INVALID_GRALLOC_OBJECT_IMG               0x40D5

        /******************************************
         * cl_img_generate_mipmap extension *
         ******************************************/
        //        const int cl_img_generate_mipmap 1

        //typedef uint cl_mipmap_filter_mode_img;

        //        /* To be used by clEnqueueGenerateMipmapIMG */
        //        const int CL_MIPMAP_FILTER_ANY_IMG 0x0
        //const int CL_MIPMAP_FILTER_BOX_IMG 0x1

        ///* To be used by clGetEventInfo */
        //const int CL_COMMAND_GENERATE_MIPMAP_IMG 0x40D6

        /******************************************
 * cl_img_mem_properties extension *
 ******************************************/
        //        const int cl_img_mem_properties 1

        ///* To be used by clCreateBufferWithProperties */
        //const int CL_MEM_ALLOC_FLAGS_IMG 0x40D7

        ///* To be used wiith the CL_MEM_ALLOC_FLAGS_IMG property */
        //typedef ulong cl_mem_alloc_flags_img;

        //        /* To be used with cl_mem_alloc_flags_img */
        //        const int CL_MEM_ALLOC_RELAX_REQUIREMENTS_IMG (1 << 0)

        ///*********************************
        //* cl_khr_subgroups extension
        //*********************************/
        //const int cl_khr_subgroups 1

        /* cl_kernel_sub_group_info */
        //        const int CL_KERNEL_MAX_SUB_GROUP_SIZE_FOR_NDRANGE_KHR    0x2033
        //const int CL_KERNEL_SUB_GROUP_COUNT_FOR_NDRANGE_KHR       0x2034


        /*********************************
        * cl_khr_mipmap_image extension
        *********************************/

        //        /* CLSamplerProperties */
        //        const int CL_SAMPLER_MIP_FILTER_MODE_KHR              0x1155
        //const int CL_SAMPLER_LOD_MIN_KHR                      0x1156
        //const int CL_SAMPLER_LOD_MAX_KHR                      0x1157


        ///*********************************
        //* cl_khr_priority_hints extension
        //*********************************/
        //        /* This extension define is for backwards compatibility.
        //           It shouldn't be required since this extension has no new functions. */
        //const int cl_khr_priority_hints 1


        //        /* CLCommandQueueProperties */
        //        const int CL_QUEUE_PRIORITY_KHR 0x1096

        ///* cl_queue_priority_khr */
        //const int CL_QUEUE_PRIORITY_HIGH_KHR (1 << 0)
        //const int CL_QUEUE_PRIORITY_MED_KHR (1 << 1)
        //const int CL_QUEUE_PRIORITY_LOW_KHR (1 << 2)


        ///*********************************
        //* cl_khr_throttle_hints extension
        //*********************************/
        //        /* This extension define is for backwards compatibility.
        //           It shouldn't be required since this extension has no new functions. */
        //const int cl_khr_throttle_hints 1


        //        /* CLCommandQueueProperties */
        //        const int CL_QUEUE_THROTTLE_KHR 0x1097

        ///* cl_queue_throttle_khr */
        //const int CL_QUEUE_THROTTLE_HIGH_KHR (1 << 0)
        //const int CL_QUEUE_THROTTLE_MED_KHR (1 << 1)
        //const int CL_QUEUE_THROTTLE_LOW_KHR (1 << 2)


        ///*********************************
        //* cl_khr_subgroup_named_barrier
        //*********************************/
        //        /* This extension define is for backwards compatibility.
        //           It shouldn't be required since this extension has no new functions. */
        //const int cl_khr_subgroup_named_barrier 1

        ///* CLDeviceInfo */
        //const int CL_DEVICE_MAX_NAMED_BARRIER_COUNT_KHR       0x2035


        ///*********************************
        //* cl_khr_extended_versioning
        //*********************************/

        //const int cl_khr_extended_versioning 1

        //const int CL_VERSION_MAJOR_BITS_KHR (10)
        //const int CL_VERSION_MINOR_BITS_KHR (10)
        //const int CL_VERSION_PATCH_BITS_KHR (12)

        //const int CL_VERSION_MAJOR_MASK_KHR ((1 << CL_VERSION_MAJOR_BITS_KHR) - 1)
        //const int CL_VERSION_MINOR_MASK_KHR ((1 << CL_VERSION_MINOR_BITS_KHR) - 1)
        //const int CL_VERSION_PATCH_MASK_KHR ((1 << CL_VERSION_PATCH_BITS_KHR) - 1)

        //const int CL_VERSION_MAJOR_KHR(version) ((version) >> (CL_VERSION_MINOR_BITS_KHR + CL_VERSION_PATCH_BITS_KHR))
        //const int CL_VERSION_MINOR_KHR(version) (((version) >> CL_VERSION_PATCH_BITS_KHR) & CL_VERSION_MINOR_MASK_KHR)
        //const int CL_VERSION_PATCH_KHR(version) ((version) & CL_VERSION_PATCH_MASK_KHR)

        //const int CL_MAKE_VERSION_KHR(major, minor, patch) \
        //((((major) & CL_VERSION_MAJOR_MASK_KHR) << (CL_VERSION_MINOR_BITS_KHR + CL_VERSION_PATCH_BITS_KHR)) | \
        //    (((minor) & CL_VERSION_MINOR_MASK_KHR) << CL_VERSION_PATCH_BITS_KHR) | \
        //    ((patch) & CL_VERSION_PATCH_MASK_KHR))


        //        const int CL_NAME_VERSION_MAX_NAME_SIZE_KHR 64


        ///* uint */
        //const int CL_PLATFORM_NUMERIC_VERSION_KHR                  0x0906
        //const int CL_PLATFORM_EXTENSIONS_WITH_VERSION_KHR          0x0907

        ///* CLDeviceInfo */
        //const int CL_DEVICE_NUMERIC_VERSION_KHR                    0x105E
        //const int CL_DEVICE_OPENCL_C_NUMERIC_VERSION_KHR           0x105F
        //const int CL_DEVICE_EXTENSIONS_WITH_VERSION_KHR            0x1060
        //const int CL_DEVICE_ILS_WITH_VERSION_KHR                   0x1061
        //const int CL_DEVICE_BUILT_IN_KERNELS_WITH_VERSION_KHR      0x1062


        ///*********************************
        //* cl_khr_device_uuid extension
        //*********************************/
        //const int cl_khr_device_uuid 1

        //const int CL_UUID_SIZE_KHR 16
        //const int CL_LUID_SIZE_KHR 8

        //const int CL_DEVICE_UUID_KHR          0x106A
        //const int CL_DRIVER_UUID_KHR          0x106B
        //const int CL_DEVICE_LUID_VALID_KHR    0x106C
        //const int CL_DEVICE_LUID_KHR          0x106D
        //const int CL_DEVICE_NODE_MASK_KHR     0x106E


        ///***************************************************************
        //* cl_khr_pci_bus_info
        //***************************************************************/
        //const int cl_khr_pci_bus_info 1


        ///* CLDeviceInfo */
        //const int CL_DEVICE_PCI_BUS_INFO_KHR                          0x410F


        /***************************************************************
        * cl_khr_suggested_local_work_size
        ***************************************************************/
        //const int cl_khr_suggested_local_work_size 1

        /***************************************************************
        * cl_khr_integer_dot_product
        ***************************************************************/
        //const int cl_khr_integer_dot_product 1

        /* cl_device_integer_dot_product_capabilities_khr */
        //        const int CL_DEVICE_INTEGER_DOT_PRODUCT_INPUT_4x8BIT_PACKED_KHR (1 << 0)
        //const int CL_DEVICE_INTEGER_DOT_PRODUCT_INPUT_4x8BIT_KHR      (1 << 1)


        /***************************************************************
        * cl_khr_integer_dot_product
        ***************************************************************/


        //        /* CLDeviceInfo */
        //        const int CL_DEVICE_INTEGER_DOT_PRODUCT_CAPABILITIES_KHR                          0x1073
        //const int CL_DEVICE_INTEGER_DOT_PRODUCT_ACCELERATION_PROPERTIES_8BIT_KHR          0x1074
        //const int CL_DEVICE_INTEGER_DOT_PRODUCT_ACCELERATION_PROPERTIES_4x8BIT_PACKED_KHR 0x1075


        ///***************************************************************
        //* cl_khr_external_memory
        //***************************************************************/
        //const int cl_khr_external_memory 1

        //typedef uint cl_external_memory_handle_type_khr;

        //        /* uint */
        //        const int CL_PLATFORM_EXTERNAL_MEMORY_IMPORT_HANDLE_TYPES_KHR 0x2044

        ///* CLDeviceInfo */
        //const int CL_DEVICE_EXTERNAL_MEMORY_IMPORT_HANDLE_TYPES_KHR   0x204F

        ///* cl_mem_properties */
        //const int CL_DEVICE_HANDLE_LIST_KHR                           0x2051
        //const int CL_DEVICE_HANDLE_LIST_END_KHR                       0

        ///* CLCommandType */
        //const int CL_COMMAND_ACQUIRE_EXTERNAL_MEM_OBJECTS_KHR         0x2047
        //const int CL_COMMAND_RELEASE_EXTERNAL_MEM_OBJECTS_KHR         0x2048


        /***************************************************************
        * cl_khr_external_memory_dma_buf
        ***************************************************************/
        //        const int cl_khr_external_memory_dma_buf 1

        ///* cl_external_memory_handle_type_khr */
        //const int CL_EXTERNAL_MEMORY_HANDLE_DMA_BUF_KHR               0x2067

        ///***************************************************************
        //* cl_khr_external_memory_dx
        //***************************************************************/
        //const int cl_khr_external_memory_dx 1

        ///* cl_external_memory_handle_type_khr */
        //const int CL_EXTERNAL_MEMORY_HANDLE_D3D11_TEXTURE_KHR         0x2063
        //const int CL_EXTERNAL_MEMORY_HANDLE_D3D11_TEXTURE_KMT_KHR     0x2064
        //const int CL_EXTERNAL_MEMORY_HANDLE_D3D12_HEAP_KHR            0x2065
        //const int CL_EXTERNAL_MEMORY_HANDLE_D3D12_RESOURCE_KHR        0x2066

        ///***************************************************************
        //* cl_khr_external_memory_opaque_fd
        //***************************************************************/
        //const int cl_khr_external_memory_opaque_fd 1

        ///* cl_external_memory_handle_type_khr */
        //const int CL_EXTERNAL_MEMORY_HANDLE_OPAQUE_FD_KHR             0x2060

        ///***************************************************************
        //* cl_khr_external_memory_win32
        //***************************************************************/
        //const int cl_khr_external_memory_win32 1

        ///* cl_external_memory_handle_type_khr */
        //const int CL_EXTERNAL_MEMORY_HANDLE_OPAQUE_WIN32_KHR          0x2061
        //const int CL_EXTERNAL_MEMORY_HANDLE_OPAQUE_WIN32_KMT_KHR      0x2062

        ///***************************************************************
        //* cl_khr_external_semaphore
        //***************************************************************/
        //const int cl_khr_external_semaphore 1

        //        /* uint */
        //        const int CL_PLATFORM_SEMAPHORE_IMPORT_HANDLE_TYPES_KHR       0x2037
        //const int CL_PLATFORM_SEMAPHORE_EXPORT_HANDLE_TYPES_KHR       0x2038

        ///* CLDeviceInfo */
        //const int CL_DEVICE_SEMAPHORE_IMPORT_HANDLE_TYPES_KHR         0x204D
        //const int CL_DEVICE_SEMAPHORE_EXPORT_HANDLE_TYPES_KHR         0x204E

        ///* cl_semaphore_properties_khr */
        //const int CL_SEMAPHORE_EXPORT_HANDLE_TYPES_KHR                0x203F
        //const int CL_SEMAPHORE_EXPORT_HANDLE_TYPES_LIST_END_KHR       0



        //        /***************************************************************
        //        * cl_khr_external_semaphore_dx_fence
        //        ***************************************************************/
        //        const int cl_khr_external_semaphore_dx_fence 1

        ///* cl_external_semaphore_handle_type_khr */
        //const int CL_SEMAPHORE_HANDLE_D3D12_FENCE_KHR                 0x2059

        ///***************************************************************
        //* cl_khr_external_semaphore_opaque_fd
        //***************************************************************/
        //const int cl_khr_external_semaphore_opaque_fd 1

        ///* cl_external_semaphore_handle_type_khr */
        //const int CL_SEMAPHORE_HANDLE_OPAQUE_FD_KHR                   0x2055

        ///***************************************************************
        //* cl_khr_external_semaphore_sync_fd
        //***************************************************************/
        //const int cl_khr_external_semaphore_sync_fd 1

        ///* cl_external_semaphore_handle_type_khr */
        //const int CL_SEMAPHORE_HANDLE_SYNC_FD_KHR                     0x2058

        ///***************************************************************
        //* cl_khr_external_semaphore_win32
        //***************************************************************/
        //const int cl_khr_external_semaphore_win32 1

        ///* cl_external_semaphore_handle_type_khr */
        //const int CL_SEMAPHORE_HANDLE_OPAQUE_WIN32_KHR                0x2056
        //const int CL_SEMAPHORE_HANDLE_OPAQUE_WIN32_KMT_KHR            0x2057

        //        *************************************************************
        //* cl_khr_semaphore
        //***************************************************************/
        //const int cl_khr_semaphore 1


        //        /* cl_semaphore_type */
        //        const int CL_SEMAPHORE_TYPE_BINARY_KHR                        1

        ///* uint */
        //const int CL_PLATFORM_SEMAPHORE_TYPES_KHR                     0x2036

        ///* CLDeviceInfo */
        //const int CL_DEVICE_SEMAPHORE_TYPES_KHR                       0x204C

        ///* cl_semaphore_info_khr */
        //const int CL_SEMAPHORE_CONTEXT_KHR                            0x2039
        //const int CL_SEMAPHORE_REFERENCE_COUNT_KHR                    0x203A
        //const int CL_SEMAPHORE_PROPERTIES_KHR                         0x203B
        //const int CL_SEMAPHORE_PAYLOAD_KHR                            0x203C

        ///* cl_semaphore_info_khr or cl_semaphore_properties_khr */
        //const int CL_SEMAPHORE_TYPE_KHR                               0x203D
        ///* enum CL_DEVICE_HANDLE_LIST_KHR */
        //        /* enum CL_DEVICE_HANDLE_LIST_END_KHR */

        //        /* CLCommandType */
        //const int CL_COMMAND_SEMAPHORE_WAIT_KHR                       0x2042
        //const int CL_COMMAND_SEMAPHORE_SIGNAL_KHR                     0x2043

        ///* Error codes */
        //const int CL_INVALID_SEMAPHORE_KHR                            -1142


        /**********************************
         * cl_arm_import_memory extension *
         **********************************/
        //        const int cl_arm_import_memory 1

        //typedef intptr_t cl_import_properties_arm;

        ///* Default and valid proporties name for cl_arm_import_memory */
        //const int CL_IMPORT_TYPE_ARM                        0x40B2

        ///* Host process memory type default value for CL_IMPORT_TYPE_ARM property */
        //const int CL_IMPORT_TYPE_HOST_ARM                   0x40B3

        ///* DMA BUF memory type value for CL_IMPORT_TYPE_ARM property */
        //const int CL_IMPORT_TYPE_DMA_BUF_ARM                0x40B4

        ///* Protected memory property */
        //const int CL_IMPORT_TYPE_PROTECTED_ARM              0x40B5

        ///* Android hardware buffer type value for CL_IMPORT_TYPE_ARM property */
        //const int CL_IMPORT_TYPE_ANDROID_HARDWARE_BUFFER_ARM 0x41E2

        ///* Data consistency with host property */
        //const int CL_IMPORT_DMA_BUF_DATA_CONSISTENCY_WITH_HOST_ARM 0x41E3

        ///* Index of plane in a multiplanar hardware buffer */
        //const int CL_IMPORT_ANDROID_HARDWARE_BUFFER_PLANE_INDEX_ARM 0x41EF

        ///* Index of layer in a multilayer hardware buffer */
        //const int CL_IMPORT_ANDROID_HARDWARE_BUFFER_LAYER_INDEX_ARM 0x41F0

        ///* Import memory size value to indicate a size for the whole buffer */
        //const int CL_IMPORT_MEMORY_WHOLE_ALLOCATION_ARM SIZE_MAX


        /******************************************
         * cl_arm_shared_virtual_memory extension *
         ******************************************/
        //        const int cl_arm_shared_virtual_memory 1

        ///* Used by GetDeviceInfo */
        //const int CL_DEVICE_SVM_CAPABILITIES_ARM                  0x40B6

        ///* Used by GetMemObjectInfo */
        //const int CL_MEM_USES_SVM_POINTER_ARM                     0x40B7

        ///* Used by clSetKernelExecInfoARM: */
        //const int CL_KERNEL_EXEC_INFO_SVM_PTRS_ARM                0x40B8
        //const int CL_KERNEL_EXEC_INFO_SVM_FINE_GRAIN_SYSTEM_ARM   0x40B9

        ///* To be used by clGetEventInfo: */
        //const int CL_COMMAND_SVM_FREE_ARM                         0x40BA
        //const int CL_COMMAND_SVM_MEMCPY_ARM                       0x40BB
        //const int CL_COMMAND_SVM_MEMFILL_ARM                      0x40BC
        //const int CL_COMMAND_SVM_MAP_ARM                          0x40BD
        //const int CL_COMMAND_SVM_UNMAP_ARM                        0x40BE

        ///* Flag values returned by GetDeviceInfo with CL_DEVICE_SVM_CAPABILITIES_ARM as the param_name. */
        //const int CL_DEVICE_SVM_COARSE_GRAIN_BUFFER_ARM           (1 << 0)
        //const int CL_DEVICE_SVM_FINE_GRAIN_BUFFER_ARM             (1 << 1)
        //const int CL_DEVICE_SVM_FINE_GRAIN_SYSTEM_ARM             (1 << 2)
        //const int CL_DEVICE_SVM_ATOMICS_ARM                       (1 << 3)

        ///* Flag values used by clSVMAllocARM: */
        //const int CL_MEM_SVM_FINE_GRAIN_BUFFER_ARM                (1 << 10)
        //const int CL_MEM_SVM_ATOMICS_ARM                          (1 << 11)



        /********************************
         * cl_arm_get_core_id extension *
         ********************************/

        //        const int cl_arm_get_core_id 1

        ///* Device info property for bitfield of cores present */
        //const int CL_DEVICE_COMPUTE_UNITS_BITFIELD_ARM      0x40BF


        ///*********************************
        //* cl_arm_job_slot_selection
        //*********************************/

        //const int cl_arm_job_slot_selection 1

        ///* CLDeviceInfo */
        //const int CL_DEVICE_JOB_SLOTS_ARM                   0x41E0

        ///* CLCommandQueueProperties */
        //const int CL_QUEUE_JOB_SLOT_ARM                     0x41E1

        ///*********************************
        //* cl_arm_scheduling_controls
        //*********************************/

        //const int cl_arm_scheduling_controls 1


        //        /* CLDeviceInfo */
        //        const int CL_DEVICE_SCHEDULING_CONTROLS_CAPABILITIES_ARM          0x41E4

        //const int CL_DEVICE_SCHEDULING_KERNEL_BATCHING_ARM               (1 << 0)
        //const int CL_DEVICE_SCHEDULING_WORKGROUP_BATCH_SIZE_ARM          (1 << 1)
        //const int CL_DEVICE_SCHEDULING_WORKGROUP_BATCH_SIZE_MODIFIER_ARM (1 << 2)
        //const int CL_DEVICE_SCHEDULING_DEFERRED_FLUSH_ARM                (1 << 3)
        //const int CL_DEVICE_SCHEDULING_REGISTER_ALLOCATION_ARM           (1 << 4)

        //const int CL_DEVICE_SUPPORTED_REGISTER_ALLOCATIONS_ARM            0x41EB

        ///* CLKernelInfo */
        //const int CL_KERNEL_EXEC_INFO_WORKGROUP_BATCH_SIZE_ARM            0x41E5
        //const int CL_KERNEL_EXEC_INFO_WORKGROUP_BATCH_SIZE_MODIFIER_ARM   0x41E6

        ///* cl_queue_properties */
        //const int CL_QUEUE_KERNEL_BATCHING_ARM                            0x41E7
        //const int CL_QUEUE_DEFERRED_FLUSH_ARM                             0x41EC

        ///**************************************
        //* cl_arm_controlled_kernel_termination
        //***************************************/

        //const int cl_arm_controlled_kernel_termination 1

        ///* Error code to indicate kernel terminated with failure */
        //const int CL_COMMAND_TERMINATED_ITSELF_WITH_FAILURE_ARM -1108

        ///* CLDeviceInfo */
        //const int CL_DEVICE_CONTROLLED_TERMINATION_CAPABILITIES_ARM 0x41EE


        //        const int CL_DEVICE_CONTROLLED_TERMINATION_SUCCESS_ARM (1 << 0)
        //const int CL_DEVICE_CONTROLLED_TERMINATION_FAILURE_ARM (1 << 1)
        //const int CL_DEVICE_CONTROLLED_TERMINATION_QUERY_ARM (1 << 2)

        ///* CLEventInfo */
        //const int CL_EVENT_COMMAND_TERMINATION_REASON_ARM 0x41ED


        //        const int CL_COMMAND_TERMINATION_COMPLETION_ARM  0
        //const int CL_COMMAND_TERMINATION_CONTROLLED_SUCCESS_ARM 1
        //const int CL_COMMAND_TERMINATION_CONTROLLED_FAILURE_ARM 2
        //const int CL_COMMAND_TERMINATION_ERROR_ARM 3

        ///*************************************
        //* cl_arm_protected_memory_allocation *
        //*************************************/

        //const int cl_arm_protected_memory_allocation 1

        //const int CL_MEM_PROTECTED_ALLOC_ARM (1ULL << 36)

        ///******************************************
        //* cl_intel_exec_by_local_thread extension *
        //******************************************/

        //const int cl_intel_exec_by_local_thread 1

        //const int CL_QUEUE_THREAD_LOCAL_EXEC_ENABLE_INTEL      (((ulong)1) << 31)

        ///***************************************************************
        //* cl_intel_device_attribute_query
        //***************************************************************/

        //const int cl_intel_device_attribute_query 1


        //        /* cl_device_feature_capabilities_intel */
        //        const int CL_DEVICE_FEATURE_FLAG_DP4A_INTEL                   (1 << 0)
        //const int CL_DEVICE_FEATURE_FLAG_DPAS_INTEL                   (1 << 1)

        ///* CLDeviceInfo */
        //const int CL_DEVICE_IP_VERSION_INTEL                          0x4250
        //const int CL_DEVICE_ID_INTEL                                  0x4251
        //const int CL_DEVICE_NUM_SLICES_INTEL                          0x4252
        //const int CL_DEVICE_NUM_SUB_SLICES_PER_SLICE_INTEL            0x4253
        //const int CL_DEVICE_NUM_EUS_PER_SUB_SLICE_INTEL               0x4254
        //const int CL_DEVICE_NUM_THREADS_PER_EU_INTEL                  0x4255
        //const int CL_DEVICE_FEATURE_CAPABILITIES_INTEL                0x4256

        ///***********************************************
        //* cl_intel_device_partition_by_names extension *
        //************************************************/

        //const int cl_intel_device_partition_by_names 1

        //const int CL_DEVICE_PARTITION_BY_NAMES_INTEL          0x4052
        //const int CL_PARTITION_BY_NAMES_LIST_END_INTEL        -1

        ///************************************************
        //* cl_intel_accelerator extension                *
        //* cl_intel_motion_estimation extension          *
        //* cl_intel_advanced_motion_estimation extension *
        //*************************************************/

        //const int cl_intel_accelerator 1
        //const int cl_intel_motion_estimation 1
        //const int cl_intel_advanced_motion_estimation 1


        ///* error codes */
        //const int CL_INVALID_ACCELERATOR_INTEL                              -1094
        //const int CL_INVALID_ACCELERATOR_TYPE_INTEL                         -1095
        //const int CL_INVALID_ACCELERATOR_DESCRIPTOR_INTEL                   -1096
        //const int CL_ACCELERATOR_TYPE_NOT_SUPPORTED_INTEL                   -1097

        ///* cl_accelerator_type_intel */
        //const int CL_ACCELERATOR_TYPE_MOTION_ESTIMATION_INTEL               0x0

        ///* cl_accelerator_info_intel */
        //const int CL_ACCELERATOR_DESCRIPTOR_INTEL                           0x4090
        //const int CL_ACCELERATOR_REFERENCE_COUNT_INTEL                      0x4091
        //const int CL_ACCELERATOR_CONTEXT_INTEL                              0x4092
        //const int CL_ACCELERATOR_TYPE_INTEL                                 0x4093

        ///* cl_motion_detect_desc_intel flags */
        //const int CL_ME_MB_TYPE_16x16_INTEL                                 0x0
        //const int CL_ME_MB_TYPE_8x8_INTEL                                   0x1
        //const int CL_ME_MB_TYPE_4x4_INTEL                                   0x2

        //const int CL_ME_SUBPIXEL_MODE_INTEGER_INTEL                         0x0
        //const int CL_ME_SUBPIXEL_MODE_HPEL_INTEL                            0x1
        //const int CL_ME_SUBPIXEL_MODE_QPEL_INTEL                            0x2

        //const int CL_ME_SAD_ADJUST_MODE_NONE_INTEL                          0x0
        //const int CL_ME_SAD_ADJUST_MODE_HAAR_INTEL                          0x1

        //const int CL_ME_SEARCH_PATH_RADIUS_2_2_INTEL                        0x0
        //const int CL_ME_SEARCH_PATH_RADIUS_4_4_INTEL                        0x1
        //const int CL_ME_SEARCH_PATH_RADIUS_16_12_INTEL                      0x5

        //const int CL_ME_SKIP_BLOCK_TYPE_16x16_INTEL                         0x0
        //const int CL_ME_CHROMA_INTRA_PREDICT_ENABLED_INTEL                  0x1
        //const int CL_ME_LUMA_INTRA_PREDICT_ENABLED_INTEL                    0x2
        //const int CL_ME_SKIP_BLOCK_TYPE_8x8_INTEL                           0x4

        //const int CL_ME_FORWARD_INPUT_MODE_INTEL                            0x1
        //const int CL_ME_BACKWARD_INPUT_MODE_INTEL                           0x2
        //const int CL_ME_BIDIRECTION_INPUT_MODE_INTEL                        0x3

        //const int CL_ME_BIDIR_WEIGHT_QUARTER_INTEL                          16
        //const int CL_ME_BIDIR_WEIGHT_THIRD_INTEL                            21
        //const int CL_ME_BIDIR_WEIGHT_HALF_INTEL                             32
        //const int CL_ME_BIDIR_WEIGHT_TWO_THIRD_INTEL                        43
        //const int CL_ME_BIDIR_WEIGHT_THREE_QUARTER_INTEL                    48

        //const int CL_ME_COST_PENALTY_NONE_INTEL                             0x0
        //const int CL_ME_COST_PENALTY_LOW_INTEL                              0x1
        //const int CL_ME_COST_PENALTY_NORMAL_INTEL                           0x2
        //const int CL_ME_COST_PENALTY_HIGH_INTEL                             0x3

        //const int CL_ME_COST_PRECISION_QPEL_INTEL                           0x0
        //const int CL_ME_COST_PRECISION_HPEL_INTEL                           0x1
        //const int CL_ME_COST_PRECISION_PEL_INTEL                            0x2
        //const int CL_ME_COST_PRECISION_DPEL_INTEL                           0x3

        //const int CL_ME_LUMA_PREDICTOR_MODE_VERTICAL_INTEL                  0x0
        //const int CL_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_INTEL                0x1
        //const int CL_ME_LUMA_PREDICTOR_MODE_DC_INTEL                        0x2
        //const int CL_ME_LUMA_PREDICTOR_MODE_DIAGONAL_DOWN_LEFT_INTEL        0x3

        //const int CL_ME_LUMA_PREDICTOR_MODE_DIAGONAL_DOWN_RIGHT_INTEL       0x4
        //const int CL_ME_LUMA_PREDICTOR_MODE_PLANE_INTEL                     0x4
        //const int CL_ME_LUMA_PREDICTOR_MODE_VERTICAL_RIGHT_INTEL            0x5
        //const int CL_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_DOWN_INTEL           0x6
        //const int CL_ME_LUMA_PREDICTOR_MODE_VERTICAL_LEFT_INTEL             0x7
        //const int CL_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_UP_INTEL             0x8

        //const int CL_ME_CHROMA_PREDICTOR_MODE_DC_INTEL                      0x0
        //const int CL_ME_CHROMA_PREDICTOR_MODE_HORIZONTAL_INTEL              0x1
        //const int CL_ME_CHROMA_PREDICTOR_MODE_VERTICAL_INTEL                0x2
        //const int CL_ME_CHROMA_PREDICTOR_MODE_PLANE_INTEL                   0x3

        ///* CLDeviceInfo */
        //const int CL_DEVICE_ME_VERSION_INTEL                                0x407E

        //const int CL_ME_VERSION_LEGACY_INTEL                                0x0
        //const int CL_ME_VERSION_ADVANCED_VER_1_INTEL                        0x1
        //const int CL_ME_VERSION_ADVANCED_VER_2_INTEL                        0x2


        /******************************************
        * cl_intel_simultaneous_sharing extension *
        *******************************************/

        //        const int cl_intel_simultaneous_sharing 1

        //const int CL_DEVICE_SIMULTANEOUS_INTEROPS_INTEL            0x4104
        //const int CL_DEVICE_NUM_SIMULTANEOUS_INTEROPS_INTEL        0x4105

        ///***********************************
        //* cl_intel_egl_image_yuv extension *
        //************************************/

        //const int cl_intel_egl_image_yuv 1

        //const int CL_EGL_YUV_PLANE_INTEL                           0x4107

        ///********************************
        //* cl_intel_packed_yuv extension *
        //*********************************/

        //const int cl_intel_packed_yuv 1

        //const int CL_YUYV_INTEL                                    0x4076
        //const int CL_UYVY_INTEL                                    0x4077
        //const int CL_YVYU_INTEL                                    0x4078
        //const int CL_VYUY_INTEL                                    0x4079

        ///********************************************
        //* cl_intel_required_subgroup_size extension *
        //*********************************************/

        //const int cl_intel_required_subgroup_size 1

        //const int CL_DEVICE_SUB_GROUP_SIZES_INTEL                  0x4108
        //const int CL_KERNEL_SPILL_MEM_SIZE_INTEL                   0x4109
        //const int CL_KERNEL_COMPILE_SUB_GROUP_SIZE_INTEL           0x410A

        ///****************************************
        //* cl_intel_driver_diagnostics extension *
        //*****************************************/

        //const int cl_intel_driver_diagnostics 1



        //        const int CL_CONTEXT_SHOW_DIAGNOSTICS_INTEL                0x4106

        //const int CL_CONTEXT_DIAGNOSTICS_LEVEL_ALL_INTEL           ( 0xff )
        //const int CL_CONTEXT_DIAGNOSTICS_LEVEL_GOOD_INTEL          ( 1 )
        //const int CL_CONTEXT_DIAGNOSTICS_LEVEL_BAD_INTEL           ( 1 << 1 )
        //const int CL_CONTEXT_DIAGNOSTICS_LEVEL_NEUTRAL_INTEL       ( 1 << 2 )

        ///********************************
        //* cl_intel_planar_yuv extension *
        //*********************************/

        //const int CL_NV12_INTEL                                       0x410E

        //const int CL_MEM_NO_ACCESS_INTEL                              ( 1 << 24 )
        //const int CL_MEM_ACCESS_FLAGS_UNRESTRICTED_INTEL              ( 1 << 25 )

        //const int CL_DEVICE_PLANAR_YUV_MAX_WIDTH_INTEL                0x417E
        //const int CL_DEVICE_PLANAR_YUV_MAX_HEIGHT_INTEL               0x417F

        ///*******************************************************
        //* cl_intel_device_side_avc_motion_estimation extension *
        //********************************************************/

        //const int CL_DEVICE_AVC_ME_VERSION_INTEL                      0x410B
        //const int CL_DEVICE_AVC_ME_SUPPORTS_TEXTURE_SAMPLER_USE_INTEL 0x410C
        //const int CL_DEVICE_AVC_ME_SUPPORTS_PREEMPTION_INTEL          0x410D

        //const int CL_AVC_ME_VERSION_0_INTEL                           0x0   /* No support. */
        //const int CL_AVC_ME_VERSION_1_INTEL                           0x1   /* First supported version. */

        //const int CL_AVC_ME_MAJOR_16x16_INTEL                         0x0
        //const int CL_AVC_ME_MAJOR_16x8_INTEL                          0x1
        //const int CL_AVC_ME_MAJOR_8x16_INTEL                          0x2
        //const int CL_AVC_ME_MAJOR_8x8_INTEL                           0x3

        //const int CL_AVC_ME_MINOR_8x8_INTEL                           0x0
        //const int CL_AVC_ME_MINOR_8x4_INTEL                           0x1
        //const int CL_AVC_ME_MINOR_4x8_INTEL                           0x2
        //const int CL_AVC_ME_MINOR_4x4_INTEL                           0x3

        //const int CL_AVC_ME_MAJOR_FORWARD_INTEL                       0x0
        //const int CL_AVC_ME_MAJOR_BACKWARD_INTEL                      0x1
        //const int CL_AVC_ME_MAJOR_BIDIRECTIONAL_INTEL                 0x2

        //const int CL_AVC_ME_PARTITION_MASK_ALL_INTEL                  0x0
        //const int CL_AVC_ME_PARTITION_MASK_16x16_INTEL                0x7E
        //const int CL_AVC_ME_PARTITION_MASK_16x8_INTEL                 0x7D
        //const int CL_AVC_ME_PARTITION_MASK_8x16_INTEL                 0x7B
        //const int CL_AVC_ME_PARTITION_MASK_8x8_INTEL                  0x77
        //const int CL_AVC_ME_PARTITION_MASK_8x4_INTEL                  0x6F
        //const int CL_AVC_ME_PARTITION_MASK_4x8_INTEL                  0x5F
        //const int CL_AVC_ME_PARTITION_MASK_4x4_INTEL                  0x3F

        //const int CL_AVC_ME_SEARCH_WINDOW_EXHAUSTIVE_INTEL            0x0
        //const int CL_AVC_ME_SEARCH_WINDOW_SMALL_INTEL                 0x1
        //const int CL_AVC_ME_SEARCH_WINDOW_TINY_INTEL                  0x2
        //const int CL_AVC_ME_SEARCH_WINDOW_EXTRA_TINY_INTEL            0x3
        //const int CL_AVC_ME_SEARCH_WINDOW_DIAMOND_INTEL               0x4
        //const int CL_AVC_ME_SEARCH_WINDOW_LARGE_DIAMOND_INTEL         0x5
        //const int CL_AVC_ME_SEARCH_WINDOW_RESERVED0_INTEL             0x6
        //const int CL_AVC_ME_SEARCH_WINDOW_RESERVED1_INTEL             0x7
        //const int CL_AVC_ME_SEARCH_WINDOW_CUSTOM_INTEL                0x8
        //const int CL_AVC_ME_SEARCH_WINDOW_16x12_RADIUS_INTEL          0x9
        //const int CL_AVC_ME_SEARCH_WINDOW_4x4_RADIUS_INTEL            0x2
        //const int CL_AVC_ME_SEARCH_WINDOW_2x2_RADIUS_INTEL            0xa

        //const int CL_AVC_ME_SAD_ADJUST_MODE_NONE_INTEL                0x0
        //const int CL_AVC_ME_SAD_ADJUST_MODE_HAAR_INTEL                0x2

        //const int CL_AVC_ME_SUBPIXEL_MODE_INTEGER_INTEL               0x0
        //const int CL_AVC_ME_SUBPIXEL_MODE_HPEL_INTEL                  0x1
        //const int CL_AVC_ME_SUBPIXEL_MODE_QPEL_INTEL                  0x3

        //const int CL_AVC_ME_COST_PRECISION_QPEL_INTEL                 0x0
        //const int CL_AVC_ME_COST_PRECISION_HPEL_INTEL                 0x1
        //const int CL_AVC_ME_COST_PRECISION_PEL_INTEL                  0x2
        //const int CL_AVC_ME_COST_PRECISION_DPEL_INTEL                 0x3

        //const int CL_AVC_ME_BIDIR_WEIGHT_QUARTER_INTEL                0x10
        //const int CL_AVC_ME_BIDIR_WEIGHT_THIRD_INTEL                  0x15
        //const int CL_AVC_ME_BIDIR_WEIGHT_HALF_INTEL                   0x20
        //const int CL_AVC_ME_BIDIR_WEIGHT_TWO_THIRD_INTEL              0x2B
        //const int CL_AVC_ME_BIDIR_WEIGHT_THREE_QUARTER_INTEL          0x30

        //const int CL_AVC_ME_BORDER_REACHED_LEFT_INTEL                 0x0
        //const int CL_AVC_ME_BORDER_REACHED_RIGHT_INTEL                0x2
        //const int CL_AVC_ME_BORDER_REACHED_TOP_INTEL                  0x4
        //const int CL_AVC_ME_BORDER_REACHED_BOTTOM_INTEL               0x8

        //const int CL_AVC_ME_SKIP_BLOCK_PARTITION_16x16_INTEL          0x0
        //const int CL_AVC_ME_SKIP_BLOCK_PARTITION_8x8_INTEL            0x4000

        //const int CL_AVC_ME_SKIP_BLOCK_16x16_FORWARD_ENABLE_INTEL     ( 0x1 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_16x16_BACKWARD_ENABLE_INTEL    ( 0x2 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_16x16_DUAL_ENABLE_INTEL        ( 0x3 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_FORWARD_ENABLE_INTEL       ( 0x55 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_BACKWARD_ENABLE_INTEL      ( 0xAA << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_DUAL_ENABLE_INTEL          ( 0xFF << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_0_FORWARD_ENABLE_INTEL     ( 0x1 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_0_BACKWARD_ENABLE_INTEL    ( 0x2 << 24 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_1_FORWARD_ENABLE_INTEL     ( 0x1 << 26 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_1_BACKWARD_ENABLE_INTEL    ( 0x2 << 26 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_2_FORWARD_ENABLE_INTEL     ( 0x1 << 28 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_2_BACKWARD_ENABLE_INTEL    ( 0x2 << 28 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_3_FORWARD_ENABLE_INTEL     ( 0x1 << 30 )
        //const int CL_AVC_ME_SKIP_BLOCK_8x8_3_BACKWARD_ENABLE_INTEL    ( 0x2 << 30 )

        //const int CL_AVC_ME_BLOCK_BASED_SKIP_4x4_INTEL                0x00
        //const int CL_AVC_ME_BLOCK_BASED_SKIP_8x8_INTEL                0x80

        //const int CL_AVC_ME_INTRA_16x16_INTEL                         0x0
        //const int CL_AVC_ME_INTRA_8x8_INTEL                           0x1
        //const int CL_AVC_ME_INTRA_4x4_INTEL                           0x2

        //const int CL_AVC_ME_INTRA_LUMA_PARTITION_MASK_16x16_INTEL     0x6
        //const int CL_AVC_ME_INTRA_LUMA_PARTITION_MASK_8x8_INTEL       0x5
        //const int CL_AVC_ME_INTRA_LUMA_PARTITION_MASK_4x4_INTEL       0x3

        //const int CL_AVC_ME_INTRA_NEIGHBOR_LEFT_MASK_ENABLE_INTEL         0x60
        //const int CL_AVC_ME_INTRA_NEIGHBOR_UPPER_MASK_ENABLE_INTEL        0x10
        //const int CL_AVC_ME_INTRA_NEIGHBOR_UPPER_RIGHT_MASK_ENABLE_INTEL  0x8
        //const int CL_AVC_ME_INTRA_NEIGHBOR_UPPER_LEFT_MASK_ENABLE_INTEL   0x4

        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_VERTICAL_INTEL            0x0
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_INTEL          0x1
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_DC_INTEL                  0x2
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_DIAGONAL_DOWN_LEFT_INTEL  0x3
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_DIAGONAL_DOWN_RIGHT_INTEL 0x4
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_PLANE_INTEL               0x4
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_VERTICAL_RIGHT_INTEL      0x5
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_DOWN_INTEL     0x6
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_VERTICAL_LEFT_INTEL       0x7
        //const int CL_AVC_ME_LUMA_PREDICTOR_MODE_HORIZONTAL_UP_INTEL       0x8
        //const int CL_AVC_ME_CHROMA_PREDICTOR_MODE_DC_INTEL                0x0
        //const int CL_AVC_ME_CHROMA_PREDICTOR_MODE_HORIZONTAL_INTEL        0x1
        //const int CL_AVC_ME_CHROMA_PREDICTOR_MODE_VERTICAL_INTEL          0x2
        //const int CL_AVC_ME_CHROMA_PREDICTOR_MODE_PLANE_INTEL             0x3

        //const int CL_AVC_ME_FRAME_FORWARD_INTEL                       0x1
        //const int CL_AVC_ME_FRAME_BACKWARD_INTEL                      0x2
        //const int CL_AVC_ME_FRAME_DUAL_INTEL                          0x3

        //const int CL_AVC_ME_SLICE_TYPE_PRED_INTEL                     0x0
        //const int CL_AVC_ME_SLICE_TYPE_BPRED_INTEL                    0x1
        //const int CL_AVC_ME_SLICE_TYPE_INTRA_INTEL                    0x2

        //const int CL_AVC_ME_INTERLACED_SCAN_TOP_FIELD_INTEL           0x0
        //const int CL_AVC_ME_INTERLACED_SCAN_BOTTOM_FIELD_INTEL        0x1

        ///*******************************************
        //* cl_intel_unified_shared_memory extension *
        //********************************************/
        //const int cl_intel_unified_shared_memory 1

        //        /* CLDeviceInfo */
        //        const int CL_DEVICE_HOST_MEM_CAPABILITIES_INTEL               0x4190
        //const int CL_DEVICE_DEVICE_MEM_CAPABILITIES_INTEL             0x4191
        //const int CL_DEVICE_SINGLE_DEVICE_SHARED_MEM_CAPABILITIES_INTEL 0x4192
        //const int CL_DEVICE_CROSS_DEVICE_SHARED_MEM_CAPABILITIES_INTEL 0x4193
        //const int CL_DEVICE_SHARED_SYSTEM_MEM_CAPABILITIES_INTEL      0x4194

        ///* cl_device_unified_shared_memory_capabilities_intel - bitfield */
        //const int CL_UNIFIED_SHARED_MEMORY_ACCESS_INTEL               (1 << 0)
        //const int CL_UNIFIED_SHARED_MEMORY_ATOMIC_ACCESS_INTEL        (1 << 1)
        //const int CL_UNIFIED_SHARED_MEMORY_CONCURRENT_ACCESS_INTEL    (1 << 2)
        //const int CL_UNIFIED_SHARED_MEMORY_CONCURRENT_ATOMIC_ACCESS_INTEL (1 << 3)

        ///* cl_mem_properties_intel */
        //const int CL_MEM_ALLOC_FLAGS_INTEL                            0x4195

        ///* cl_mem_alloc_flags_intel - bitfield */
        //const int CL_MEM_ALLOC_WRITE_COMBINED_INTEL                   (1 << 0)
        //const int CL_MEM_ALLOC_INITIAL_PLACEMENT_DEVICE_INTEL         (1 << 1)
        //const int CL_MEM_ALLOC_INITIAL_PLACEMENT_HOST_INTEL           (1 << 2)

        ///* cl_mem_alloc_info_intel */
        //const int CL_MEM_ALLOC_TYPE_INTEL                             0x419A
        //const int CL_MEM_ALLOC_BASE_PTR_INTEL                         0x419B
        //const int CL_MEM_ALLOC_SIZE_INTEL                             0x419C
        //const int CL_MEM_ALLOC_DEVICE_INTEL                           0x419D

        ///* cl_unified_shared_memory_type_intel */
        //const int CL_MEM_TYPE_UNKNOWN_INTEL                           0x4196
        //const int CL_MEM_TYPE_HOST_INTEL                              0x4197
        //const int CL_MEM_TYPE_DEVICE_INTEL                            0x4198
        //const int CL_MEM_TYPE_SHARED_INTEL                            0x4199

        ///* CLKernelExecInfo */
        //const int CL_KERNEL_EXEC_INFO_INDIRECT_HOST_ACCESS_INTEL      0x4200
        //const int CL_KERNEL_EXEC_INFO_INDIRECT_DEVICE_ACCESS_INTEL    0x4201
        //const int CL_KERNEL_EXEC_INFO_INDIRECT_SHARED_ACCESS_INTEL    0x4202
        //const int CL_KERNEL_EXEC_INFO_USM_PTRS_INTEL                  0x4203

        ///* CLCommandType */
        //const int CL_COMMAND_MEMFILL_INTEL                            0x4204
        //const int CL_COMMAND_MEMCPY_INTEL                             0x4205
        //const int CL_COMMAND_MIGRATEMEM_INTEL                         0x4206
        //const int CL_COMMAND_MEMADVISE_INTEL                          0x4207


        /***************************************************************
        * cl_intel_mem_alloc_buffer_location
        ***************************************************************/
        //        const int cl_intel_mem_alloc_buffer_location 1
        //const int CL_INTEL_MEM_ALLOC_BUFFER_LOCATION_EXTENSION_NAME \
        //"cl_intel_mem_alloc_buffer_location"

        ///* cl_mem_properties_intel */
        //const int CL_MEM_ALLOC_BUFFER_LOCATION_INTEL                  0x419E

        ///* cl_mem_alloc_info_intel */
        //        /* enum CL_MEM_ALLOC_BUFFER_LOCATION_INTEL */


        /***************************************************
        * cl_intel_create_buffer_with_properties extension *
        ****************************************************/

        //const int cl_intel_create_buffer_with_properties 1


        /******************************************
        * cl_intel_mem_channel_property extension *
        *******************************************/

        //        const int CL_MEM_CHANNEL_INTEL            0x4213

        ///*********************************
        //* cl_intel_mem_force_host_memory *
        //**********************************/

        //const int cl_intel_mem_force_host_memory 1

        ///* CLMemoryFlags */
        //const int CL_MEM_FORCE_HOST_MEMORY_INTEL                      (1 << 20)

        ///***************************************************************
        //* cl_intel_command_queue_families
        //***************************************************************/
        //const int cl_intel_command_queue_families 1


        //        const int CL_QUEUE_FAMILY_MAX_NAME_SIZE_INTEL                 64


        ///* CLDeviceInfo */
        //const int CL_DEVICE_QUEUE_FAMILY_PROPERTIES_INTEL             0x418B

        ///* cl_queue_properties */
        //const int CL_QUEUE_FAMILY_INTEL                               0x418C
        //const int CL_QUEUE_INDEX_INTEL                                0x418D

        ///* cl_command_queue_capabilities_intel */
        //const int CL_QUEUE_DEFAULT_CAPABILITIES_INTEL                 0
        //const int CL_QUEUE_CAPABILITY_CREATE_SINGLE_QUEUE_EVENTS_INTEL (1 << 0)
        //const int CL_QUEUE_CAPABILITY_CREATE_CROSS_QUEUE_EVENTS_INTEL (1 << 1)
        //const int CL_QUEUE_CAPABILITY_SINGLE_QUEUE_EVENT_WAIT_LIST_INTEL (1 << 2)
        //const int CL_QUEUE_CAPABILITY_CROSS_QUEUE_EVENT_WAIT_LIST_INTEL (1 << 3)
        //const int CL_QUEUE_CAPABILITY_TRANSFER_BUFFER_INTEL           (1 << 8)
        //const int CL_QUEUE_CAPABILITY_TRANSFER_BUFFER_RECT_INTEL      (1 << 9)
        //const int CL_QUEUE_CAPABILITY_MAP_BUFFER_INTEL                (1 << 10)
        //const int CL_QUEUE_CAPABILITY_FILL_BUFFER_INTEL               (1 << 11)
        //const int CL_QUEUE_CAPABILITY_TRANSFER_IMAGE_INTEL            (1 << 12)
        //const int CL_QUEUE_CAPABILITY_MAP_IMAGE_INTEL                 (1 << 13)
        //const int CL_QUEUE_CAPABILITY_FILL_IMAGE_INTEL                (1 << 14)
        //const int CL_QUEUE_CAPABILITY_TRANSFER_BUFFER_IMAGE_INTEL     (1 << 15)
        //const int CL_QUEUE_CAPABILITY_TRANSFER_IMAGE_BUFFER_INTEL     (1 << 16)
        //const int CL_QUEUE_CAPABILITY_MARKER_INTEL                    (1 << 24)
        //const int CL_QUEUE_CAPABILITY_BARRIER_INTEL                   (1 << 25)
        //const int CL_QUEUE_CAPABILITY_KERNEL_INTEL                    (1 << 26)

        ///***************************************************************
        //* cl_intel_sharing_format_query
        //***************************************************************/
        //const int cl_intel_sharing_format_query 1


        //        /* CLGLObjectType = 0x2000 - 0x200F enum values are currently taken           */
        //        const int Buffer                     0x2000
        //const int Texture2D                  0x2001
        //const int Texture3D                  0x2002
        //const int RenderBuffer               0x2003
        //#ifdef CL_VERSION_1_2
        //const int Texture2DArray            0x200E
        //const int Texture1D                  0x200F
        //const int Texture1DArray            0x2010
        //const int TextureBuffer             0x2011
        //#endif

        ///* CLGLTextureInfo           */
        //const int TextureTarget                    0x2004
        //const int MipmapLevel                      0x2005
        //#ifdef CL_VERSION_1_2
        //const int NumberOfSamples                       0x2012
        //#endif

        /* cl_khr_gl_sharing extension  */

        //        const int cl_khr_gl_sharing 1


        //        /* Additional Error Codes  */
        //        const int CL_INVALID_GL_SHAREGROUP_REFERENCE_KHR  -1000

        ///* CLGLContextInfo  */
        //const int CurrentDeviceForGLContextKHR    0x2006
        //const int DevicesForGLContextKHR           0x2007

        ///* Additional CLContextProperties  */
        //const int GLContextKHR                       0x2008
        //const int EGLDisplayKHR                      0x2009
        //const int GLXDisplayKHR                      0x200A
        //const int WGLHDCKHR                          0x200B
        //const int CGLSharegroupKHR                   0x200C

        /* 
 *  cl_khr_gl_event extension
 */
        //const int GLFenceSyncObjectKHR     0x200D


        /***************************************************************
        * cl_intel_sharing_format_query_gl
        ***************************************************************/
        //const int cl_intel_sharing_format_query_gl 1
    }
}
