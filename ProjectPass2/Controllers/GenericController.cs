using Microsoft.AspNetCore.Mvc;

namespace ProjectPass2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GenericController : ControllerBase
    {

        private readonly ILogger<GenericController> _logger;

        public GenericController(ILogger<GenericController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// /�������� ����� ��������� ������: ��������� ����� �������� ������ ������ � ������ ����
        ///  ��� ����������� ������������� � ���������, ��� ��������� 
        ///  ���������������� ������ ���� � ���� 
        ///  
        ///
        /// </summary>
        /// 
        /// 
        /// <param name="ls">�������� ��� ������ ����</param>
        /// 
        /// <param name="lp">�������� ��� ������ ������</param>
        /// <returns></returns>
       ///
        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public Class Get(int ls, int lp)
        {
            Class _class = ClassPHS.Rezerv(ls, lp);
            return _class;
        }
    }
}