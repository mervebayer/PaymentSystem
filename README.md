{
  "openapi": "3.0.1",
  "info": {
    "title": "Payment System Api Management",
    "version": "v1.0"
  },
  "paths": {
    "/api/BankInfo": {
      "post": {
        "tags": [
          "BankInfo"
        ],
        "parameters": [
          {
            "name": "UserId",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "IBAN",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "BankName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Name",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Surname",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "BankInfo"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/BankInfo/{id}": {
      "put": {
        "tags": [
          "BankInfo"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BankInfoRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BankInfoRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BankInfoRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "delete": {
        "tags": [
          "BankInfo"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "BankInfo"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/BankInfoResponseApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/EmployeeExpense": {
      "post": {
        "tags": [
          "EmployeeExpense"
        ],
        "requestBody": {
          "content": {
            "multipart/form-data": {
              "schema": {
                "type": "object",
                "properties": {
                  "Amount": {
                    "type": "number",
                    "format": "double"
                  },
                  "Location": {
                    "type": "string"
                  },
                  "Description": {
                    "type": "string"
                  },
                  "ExpenseDate": {
                    "type": "string",
                    "format": "date-time"
                  },
                  "file": {
                    "type": "string",
                    "format": "binary"
                  }
                }
              },
              "encoding": {
                "Amount": {
                  "style": "form"
                },
                "Location": {
                  "style": "form"
                },
                "Description": {
                  "style": "form"
                },
                "ExpenseDate": {
                  "style": "form"
                },
                "file": {
                  "style": "form"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "EmployeeExpense"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/EmployeeExpense/{id}": {
      "put": {
        "tags": [
          "EmployeeExpense"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EmployeeExpenseRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EmployeeExpenseRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EmployeeExpenseRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "delete": {
        "tags": [
          "EmployeeExpense"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "EmployeeExpense"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/EmployeeExpense/ByParameters": {
      "get": {
        "tags": [
          "EmployeeExpense"
        ],
        "parameters": [
          {
            "name": "Status",
            "in": "query",
            "style": "form",
            "schema": {
              "$ref": "#/components/schemas/StatusEnum"
            }
          },
          {
            "name": "Location",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "expenseDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "requestDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EmployeeExpenseResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/ManagerExpense/{id}": {
      "put": {
        "tags": [
          "ManagerExpense"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "Status",
            "in": "query",
            "style": "form",
            "schema": {
              "$ref": "#/components/schemas/StatusEnum"
            }
          },
          {
            "name": "RejectionReason",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "ManagerExpense"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/ManagerExpense": {
      "get": {
        "tags": [
          "ManagerExpense"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/ManagerExpense/ByParameters": {
      "get": {
        "tags": [
          "ManagerExpense"
        ],
        "parameters": [
          {
            "name": "Status",
            "in": "query",
            "style": "form",
            "schema": {
              "$ref": "#/components/schemas/StatusEnum"
            }
          },
          {
            "name": "Location",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "expenseDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "requestDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ManagerExpenseResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/Report/RequestStatus": {
      "get": {
        "tags": [
          "Report"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/RequestStatusCountsResponseIEnumerableApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/RequestStatusCountsResponseIEnumerableApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/RequestStatusCountsResponseIEnumerableApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/Report/ExpenseSummary": {
      "get": {
        "tags": [
          "Report"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ExpenseSummaryIEnumerableApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ExpenseSummaryIEnumerableApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ExpenseSummaryIEnumerableApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/Token": {
      "post": {
        "tags": [
          "Token"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/TokenRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/TokenRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/TokenRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/TokenResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/TokenResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/TokenResponseApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/User": {
      "post": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "IdentityNumber",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "FirstName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "LastName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "UserName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Password",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Email",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Role",
            "in": "query",
            "style": "form",
            "schema": {
              "$ref": "#/components/schemas/RoleEnum"
            }
          },
          {
            "name": "DateOfBirth",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "User"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseListApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseListApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseListApiResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/User/{id}": {
      "put": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "delete": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ApiResponse"
                }
              }
            }
          }
        }
      },
      "get": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserResponseApiResponse"
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "ApiResponse": {
        "type": "object",
        "properties": {
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          }
        },
        "additionalProperties": false
      },
      "BankInfoRequest": {
        "type": "object",
        "properties": {
          "iban": {
            "type": "string",
            "nullable": true
          },
          "bankName": {
            "type": "string",
            "nullable": true
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "surname": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "BankInfoResponse": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          },
          "iban": {
            "type": "string",
            "nullable": true
          },
          "bankName": {
            "type": "string",
            "nullable": true
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "surname": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "BankInfoResponseApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "$ref": "#/components/schemas/BankInfoResponse"
          }
        },
        "additionalProperties": false
      },
      "BankInfoResponseListApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/BankInfoResponse"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "EmployeeExpenseRequest": {
        "type": "object",
        "properties": {
          "amount": {
            "type": "number",
            "format": "double"
          },
          "documentUrl": {
            "type": "string",
            "nullable": true
          },
          "location": {
            "type": "string",
            "nullable": true
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "expenseDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "EmployeeExpenseResponse": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "documentUrl": {
            "type": "string",
            "nullable": true
          },
          "location": {
            "type": "string",
            "nullable": true
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "$ref": "#/components/schemas/StatusEnum"
          },
          "rejectionReason": {
            "type": "string",
            "nullable": true
          },
          "expenseDate": {
            "type": "string",
            "format": "date-time"
          },
          "requestDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "EmployeeExpenseResponseApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "$ref": "#/components/schemas/EmployeeExpenseResponse"
          }
        },
        "additionalProperties": false
      },
      "EmployeeExpenseResponseListApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/EmployeeExpenseResponse"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ExpenseSummary": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "uniqueUserCount": {
            "type": "integer",
            "format": "int32"
          },
          "totalAmount": {
            "type": "number",
            "format": "double"
          },
          "averageAmount": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "ExpenseSummaryIEnumerableApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/ExpenseSummary"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ManagerExpenseResponse": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "documentUrl": {
            "type": "string",
            "nullable": true
          },
          "location": {
            "type": "string",
            "nullable": true
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "$ref": "#/components/schemas/StatusEnum"
          },
          "rejectionReason": {
            "type": "string",
            "nullable": true
          },
          "expenseDate": {
            "type": "string",
            "format": "date-time"
          },
          "requestDate": {
            "type": "string",
            "format": "date-time"
          },
          "updateUserId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "updateDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "ManagerExpenseResponseApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "$ref": "#/components/schemas/ManagerExpenseResponse"
          }
        },
        "additionalProperties": false
      },
      "ManagerExpenseResponseListApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/ManagerExpenseResponse"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RequestStatusCountsResponse": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "rejectedCount": {
            "type": "integer",
            "format": "int32"
          },
          "approvedCount": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "RequestStatusCountsResponseIEnumerableApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/RequestStatusCountsResponse"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RoleEnum": {
        "enum": [
          "Employee",
          "Manager"
        ],
        "type": "string"
      },
      "StatusEnum": {
        "enum": [
          "Pending",
          "Approved",
          "Declined"
        ],
        "type": "string"
      },
      "TokenRequest": {
        "type": "object",
        "properties": {
          "userName": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TokenResponse": {
        "type": "object",
        "properties": {
          "expireDate": {
            "type": "string",
            "format": "date-time"
          },
          "token": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TokenResponseApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "$ref": "#/components/schemas/TokenResponse"
          }
        },
        "additionalProperties": false
      },
      "UserResponse": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "identityNumber": {
            "type": "string",
            "nullable": true
          },
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "role": {
            "$ref": "#/components/schemas/RoleEnum"
          },
          "dateOfBirth": {
            "type": "string",
            "format": "date-time"
          },
          "lastActivityDate": {
            "type": "string",
            "format": "date-time"
          },
          "passwordRetryCount": {
            "type": "integer",
            "format": "int32"
          },
          "status": {
            "type": "integer",
            "format": "int32"
          },
          "expenses": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/EmployeeExpenseResponse"
            },
            "nullable": true
          },
          "bankInfos": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/BankInfoRequest"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserResponseApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "$ref": "#/components/schemas/UserResponse"
          }
        },
        "additionalProperties": false
      },
      "UserResponseListApiResponse": {
        "type": "object",
        "properties": {
          "serverDate": {
            "type": "string",
            "format": "date-time"
          },
          "referenceNo": {
            "type": "string",
            "format": "uuid"
          },
          "success": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "response": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/UserResponse"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserUpdateRequest": {
        "type": "object",
        "properties": {
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    },
    "securitySchemes": {
      "Bearer": {
        "type": "http",
        "description": "Enter JWT Bearer token **_only_**",
        "scheme": "bearer",
        "bearerFormat": "JWT"
      }
    }
  },
  "security": [
    {
      "Bearer": [ ]
    }
  ]
}
