using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AspNetCoreBlogMVC.Models.ViewModels
{
    public class AddTagRequest
    {
		[Required]
		public string Name { get; set; }
		[Required]
		public string DisplayName { get; set; }
	}
}


// sama dengan 
/* 
java
Di Spring Boot, Anda menggunakan Jakarta Bean Validation (dahulu JSR 303) melalui anotasi pada properti kelas POJO

import jakarta.validation.constraints.NotBlank;
import lombok.Data;

@Data // Menggunakan Lombok untuk getter/setter otomatis
public class AddTagRequest {
    
    @NotBlank(message = "Name is required")
    private String name;

    @NotBlank(message = "Display Name is required")
    private String displayName;
}



Go (Golang)
Di Go, tidak ada sistem anotasi bawaan seperti C#. Namun, standar industri adalah 
menggunakan Struct Tags bersama dengan pustaka go-playground/validator

type AddTagRequest struct {
    // Tag 'validate' menentukan aturan validasi
    Name        string `json:"name" validate:"required"`
    DisplayName string `json:"display_name" validate:"required"`
}
*/